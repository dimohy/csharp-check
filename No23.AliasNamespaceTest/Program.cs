using NamespaceA = No23.AliasNamespaceTest.NamespaceA;
using NamespaceB = No23.AliasNamespaceTest.NamespaceB;

using TestA = No23.AliasNamespaceTest.NamespaceA.Test;
using TestB = No23.AliasNamespaceTest.NamespaceB.Test;


No23.AliasNamespaceTest.NamespaceA.Test.Print();
No23.AliasNamespaceTest.NamespaceB.Test.Print();


NamespaceA.Test.Print();
NamespaceB.Test.Print();

NamespaceA::Test.Print();
NamespaceB::Test.Print();


TestA.Print();
TestB.Print();


global::System.Console.WriteLine("Hello World!");