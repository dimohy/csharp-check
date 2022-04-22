using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using MudBlazor;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Xml.Linq;

namespace No9.CSharpCodeRunner.Client.Pages
{
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

        private void RunCSharpSource()
        {
            outputText = RunCSharpSource(sourceText);
        }

        protected override async Task OnInitializedAsync()
        {
            //var refs = AppDomain.CurrentDomain.GetAssemblies();
            var client = new HttpClient
            {
                BaseAddress = new Uri(navigationManager.BaseUri)
            };

            var references = new List<MetadataReference>();

//foreach (var reference in refs.Where(x => !x.IsDynamic && !string.IsNullOrWhiteSpace(x.Modules.First().Name)))
//{
//    try
//    {
//        var name = reference.Modules.First().Name;
//        var stream = await client.GetStreamAsync($"_framework/{name}");
//        references.Add(MetadataReference.CreateFromStream(stream));
//    }
//    catch (Exception)
//    {
//    }
//}
            foreach (var name in usings)
            {
                try
                {
                    var stream = await client.GetStreamAsync($"_framework/{name}.dll");
                    references.Add(MetadataReference.CreateFromStream(stream));
                }
                catch
                {
                }
            }

            _references = references;
        }

        private string? RunCSharpSource(string source)
        {
            var scriptCompilation = CSharpCompilation.CreateScriptCompilation(
                Path.GetRandomFileName(),
                CSharpSyntaxTree.ParseText(source,
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
                return "";
            }

            var sb = new StringBuilder();
            foreach (var diagnostic in emitResult.Diagnostics)
            {
                sb.AppendLine(diagnostic.ToString());
            }

            return sb.ToString();
        }
    }
}
