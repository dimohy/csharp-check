using No11.ExpandoObject;

using System.ComponentModel;
using System.Dynamic;

dynamic p = new ExpandoObject();

(p as INotifyPropertyChanged)!.PropertyChanged += (s, e) =>
{
    Console.WriteLine($"Changed Property : {e.PropertyName}");
};

// Console.WriteLine(p.Name); // 아직 Name 속성이 없으므로 예외

p.Name = "David";
p.Age = 30;

IDictionary<string, object?> dic = p;

dic["Sex"] = "Male";

Console.WriteLine(p.Sex);

foreach (var kv in p)
{
    Console.WriteLine(kv);
}

p.PrintProperties = new Action(() =>
{
    foreach (var kv in p)
    {
        Console.WriteLine(kv);
    }
});

p.PrintProperties();

dynamic c = new CustomDynamicMetaObject();
c.Name = "James";
//Console.WriteLine(c.Name);