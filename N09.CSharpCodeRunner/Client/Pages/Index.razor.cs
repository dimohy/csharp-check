using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using MudBlazor;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Xml.Linq;
using System.Text.Json;
using System.Collections.Immutable;
using System.Reflection;

namespace N09.CSharpCodeRunner.Client.Pages;

public partial class Index
{
    private static IEnumerable<string> usings = new[]
    {
            "System",
            "System.IO",
            "System.Collections.Generic",
            "System.Console",
            "System.Diagnostics",
            "System.Dynamic",
            "System.Linq",
            "System.Linq.Expressions",
            "System.Net.Http",
            "System.Text",
            "System.Threading.Tasks"
    };

    private IEnumerable<MetadataReference>? _references;
    private CSharpCompilation? _previousCompilation;

    private string sourceText = "";
    private string? outputText;

    private async Task RunCSharpCode()
    {
        outputText = await RunCSharpCodeAsync(sourceText);
    }

    protected override async Task OnInitializedAsync()
    {
        var client = new HttpClient
        {
            BaseAddress = new Uri(navigationManager.BaseUri)
        };

        var references = new List<MetadataReference>();

        var refsUri = "_framework/blazor.boot.json";
        var blazorBootJson = await client.GetStringAsync(refsUri);
        var dom = JsonDocument.Parse(blazorBootJson);
        var assemblies = dom.RootElement.GetProperty("resources").GetProperty("assembly").EnumerateObject();
        foreach (var assemblyInfo in assemblies)
        {
            var name = assemblyInfo.Name;
            try
            {
                var stream = await client.GetStreamAsync($"_framework/{name}");
                references.Add(MetadataReference.CreateFromStream(stream));
            }
            catch
            {
            }
        }

        _references = references;
    }

    private async Task<string?> RunCSharpCodeAsync(string code)
    {
        var result = await Task.Run(async () =>
        {
            var scriptCompilation = CSharpCompilation.CreateScriptCompilation(
                Path.GetRandomFileName(),
                CSharpSyntaxTree.ParseText(code,
                CSharpParseOptions.Default.WithKind(SourceCodeKind.Script).WithLanguageVersion(LanguageVersion.Preview)),
                _references,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary, usings: usings),
                _previousCompilation
            );

            using var ms = new MemoryStream();
            var emitResult = scriptCompilation.Emit(ms);
            if (emitResult.Success is true)
            {
                _previousCompilation = scriptCompilation;
                var assembly = Assembly.Load(ms.ToArray());

                using var writer = new StringWriter();
                Console.SetOut(writer);
                var entryPoint = _previousCompilation.GetEntryPoint(CancellationToken.None);
                var type = assembly.GetType($"{entryPoint!.ContainingNamespace.MetadataName}.{entryPoint.ContainingType.MetadataName}");
                var entryPointMethod = type!.GetMethod(entryPoint.MetadataName);

                var submission = (Func<object[], Task>)entryPointMethod!.CreateDelegate(typeof(Func<object[], Task>));
                var submissionStates = new object[] { null!, null! };
                await submission(submissionStates);

                return writer.ToString();
            }

            var sb = new StringBuilder();
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                sb.AppendLine(diagnostic.ToString());
            }

            return sb.ToString();
        });

        return result;
    }
}
