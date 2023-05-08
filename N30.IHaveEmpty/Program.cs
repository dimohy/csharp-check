var mypet = new MyPet();
mypet.Print();

mypet.Animal = new Animal(AnimalKind.Dog, "CoCo");
mypet.Print();



class MyPet
{
    public Animal Animal { get; set; } = Animal.Empty;

    public void Print()
    {
        if (Animal.Kind is AnimalKind.Unselected)
            Console.WriteLine("No Pets.");
        else
            Console.WriteLine($"I have a {Animal.Kind} named '{Animal.Name}'.");
    }
}


interface IHaveEmpty<T>
{
    static abstract T Empty { get; }
}

record Animal : IHaveEmpty<Animal>
{
    public static Animal Empty { get; } = new Animal(AnimalKind.Unselected, "");

    public AnimalKind Kind { get; }
    public string Name { get; }

    public Animal(AnimalKind kind, string name)
    {
        Kind = kind;
        Name = name;
    }
}

enum AnimalKind
{
    Unselected,

    Dog,
    Cat,
    Pig
}
