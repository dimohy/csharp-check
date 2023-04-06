var aAction = () => Console.WriteLine("A");
var bAction = () => Console.WriteLine("B");
var cAction = aAction + bAction;

cAction();

var aFunc = () => 1;
var bFunc = () => 2;
var cFunc = aFunc + bFunc;

var result = cFunc();
Console.WriteLine(result);
