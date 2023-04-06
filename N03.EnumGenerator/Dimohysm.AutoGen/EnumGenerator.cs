using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text;

namespace Dimohysm.AutoGen;

[Generator]
public class EnumGenerator : IIncrementalGenerator
{
    private const string EnumExtensionsAttribute = "Dimohysm.AutoGen.EnumGenerators.EnumExtensionsAttribute";

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        //if (Debugger.IsAttached == false)
        //    Debugger.Launch();

        // 마커 특성 추가
        context.RegisterPostInitializationOutput(ctx => ctx.AddSource(
            "EnumExtensionsAttribute.g.cs",
            SourceText.From(SourceGenerationHelper.Attribute, Encoding.UTF8)));

        // 열거형 필터 수행
        IncrementalValuesProvider<EnumDeclarationSyntax> enumDeclarations = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: static (s, _) => IsSyntaxTargetForGeneration(s),
                transform: static (ctx, _) => GetSemanticTargetForGeneration(ctx))
            .Where(static m => m is not null)!;

        // 선택한 열거형을 "Compilation"과 결합
        IncrementalValueProvider<(Compilation, ImmutableArray<EnumDeclarationSyntax>)> compilationAndEnums = context.CompilationProvider.Combine(enumDeclarations.Collect());

        // Compilation 및 열거형을 사용하여 소스 생성
        context.RegisterSourceOutput(compilationAndEnums,
            static (spc, source) => Execute(source.Item1, source.Item2, spc));
    }

    static bool IsSyntaxTargetForGeneration(SyntaxNode node) => node is EnumDeclarationSyntax { AttributeLists.Count: > 0 };

    static EnumDeclarationSyntax? GetSemanticTargetForGeneration(GeneratorSyntaxContext context)
    {
        var enumDeclarationSyntax = (EnumDeclarationSyntax)context.Node;

        foreach (var attributeListSyntax in enumDeclarationSyntax.AttributeLists)
        {
            foreach (var attributeSyntax in attributeListSyntax.Attributes)
            {
                if (context.SemanticModel.GetSymbolInfo(attributeSyntax).Symbol is not IMethodSymbol attributeSymbol)
                {
                    // 이상합니다. 기호를 가져올 수 없습니다. 무시하십시오.
                    continue;
                }

                var attributeContainingTypeSymbol = attributeSymbol.ContainingType;
                var fullName = attributeContainingTypeSymbol.ToDisplayString();

                // 특성이 [EnumExtensions] 특성입니까?
                if (fullName is EnumExtensionsAttribute)
                {
                    // return the enum
                    return enumDeclarationSyntax;
                }
            }
        }

        // 찾고자 하는 특성을 찾지 못했습니다.
        return null;
    }

    static void Execute(Compilation compilation, ImmutableArray<EnumDeclarationSyntax> enums, SourceProductionContext context)
    {
        if (enums.IsDefaultOrEmpty)
        {
            // 아직 할 일이 없음
            return;
        }

        // 이것이 실제로 필요한지 확실하지 않지만 `[LoggerMessage]`가 수행하므로 좋은 생각인 것 같습니다!
        var  distinctEnums = enums.Distinct();

        // 각 EnumDeclarationSyntax를 EnumToGenerate로 변환
        var enumsToGenerate = GetTypesToGenerate(compilation, distinctEnums, context.CancellationToken);

        // EnumDeclarationSyntax에 오류가 있는 경우 EnumToGenerate를 생성하지 않으므로 생성할 항목이 있는지 확인합니다. 
        if (enumsToGenerate.Count > 0)
        {
            // 소스 코드를 생성하고 출력에 추가
            string result = SourceGenerationHelper.GenerateExtensionClass(enumsToGenerate);
            context.AddSource("EnumExtensions.g.cs", SourceText.From(result, Encoding.UTF8));
        }
    }

    static List<EnumToGenerate> GetTypesToGenerate(Compilation compilation, IEnumerable<EnumDeclarationSyntax> enums, CancellationToken ct)
    {
        // 출력을 저장할 목록을 만듭니다.
        var enumsToGenerate = new List<EnumToGenerate>();
        // 마커 특성의 의미론적 표현을 얻습니다.
        var enumAttribute = compilation.GetTypeByMetadataName(EnumExtensionsAttribute);

        if (enumAttribute == null)
        {
            // 이것이 null이면 Compilation에서 마커 특성 유형을 찾을 수 없습니다.
            // 이는 무언가 매우 잘못되었음을 나타냅니다. 구제..
            return enumsToGenerate;
        }

        foreach (EnumDeclarationSyntax enumDeclarationSyntax in enums)
        {
            // 우리가 요청하면 중지
            ct.ThrowIfCancellationRequested();

            // 열거형 구문의 의미론적 표현 얻기 
            var semanticModel = compilation.GetSemanticModel(enumDeclarationSyntax.SyntaxTree);
            if (semanticModel.GetDeclaredSymbol(enumDeclarationSyntax) is not INamedTypeSymbol enumSymbol)
            {
                // 뭔가 잘못되었습니다, 구제  
                continue;
            }

            // 열거형의 전체 유형 이름을 가져옵니다. e.g. Colour,
            // 또는 OuterClass<T>.Colour가 제네릭 형식에 중첩된 경우(예)
            var enumName = enumSymbol.ToString();

            // 열거형의 모든 멤버 가져오기 
            ImmutableArray<ISymbol> enumMembers = enumSymbol.GetMembers();
            var members = new List<string>(enumMembers.Length);

            // 열거형에서 모든 필드를 가져오고 해당 이름을 목록에 추가합니다. 
            foreach (ISymbol member in enumMembers)
            {
                if (member is IFieldSymbol field && field.ConstantValue is not null)
                {
                    members.Add(member.Name);
                }
            }

            // 생성 단계에서 사용할 EnumToGenerate 생성 
            enumsToGenerate.Add(new EnumToGenerate(enumName, members));
        }

        return enumsToGenerate;
    }
}

public readonly struct EnumToGenerate
{
    public readonly string Name;
    public readonly List<string> Values;

    public EnumToGenerate(string name, List<string> values)
    {
        Name = name;
        Values = values;
    }
}

public static class SourceGenerationHelper
{
    public const string Attribute = """
    namespace Dimohysm.AutoGen.EnumGenerators
    {
        [System.AttributeUsage(System.AttributeTargets.Enum)]
        public class EnumExtensionsAttribute : System.Attribute
        {
        }
    }
    """;

    public static string GenerateExtensionClass(List<EnumToGenerate> enumsToGenerate)
    {
        var sb = new StringBuilder();
        sb.Append(@"
namespace Dimohysm.AutoGen.EnumGenerators
{
    public static partial class EnumExtensions
    {");
        foreach (var enumToGenerate in enumsToGenerate)
        {
            sb.Append(@"
                public static string ToStringFast(this ").Append(enumToGenerate.Name).Append(@" value)
                    => value switch
                    {");
            foreach (var member in enumToGenerate.Values)
            {
                sb.Append(@"
                ").Append(enumToGenerate.Name).Append('.').Append(member)
                    .Append(" => nameof(")
                    .Append(enumToGenerate.Name).Append('.').Append(member).Append("),");
            }

            sb.Append(@"
                    _ => value.ToString(),
                };
");
        }

        sb.Append(@"
    }
}");

        return sb.ToString();
    }
}