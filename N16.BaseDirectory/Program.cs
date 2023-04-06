using System.Reflection;

Console.WriteLine(AppContext.BaseDirectory);

Console.WriteLine(AppContext.TargetFrameworkName);

Console.WriteLine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));