// Animal은 Animal.dll로 컴파일 되어 이미 배포되었다고 가정
// 배포된 로직에는 다음의 IAnimalCreator가 추가되어 있다고 가정
Animal.AddCreator(new AnimalCreator<Dog>());
Animal.AddCreator(new AnimalCreator<Cat>());

// 새롭게 AnimalPig.dll로 Pig가 추가되었다고 가정
Animal.AddCreator(new AnimalCreator<Pig>());


// 이후 자유롭게 Animal 개체들을 생성
//var dog = Animal.Create(1);
//var cat = Animal.Create(2);
//var pig = Animal.Create(3);

var dog = Animal.Create(Dog.AnimalType);
var cat = Animal.Create(Cat.AnimalType);
var pig = Animal.Create(Pig.AnimalType);

Console.WriteLine(dog.Name);
Console.WriteLine(cat.Name);
Console.WriteLine(pig.Name);


var animals = Enumerable.Range(1, 3).Select(x => Animal.Create(x));
foreach (var animal in animals)
    Console.WriteLine(animal.Name);


//---------


/// <summary>
/// Animal은 OCP 원칙을 준수함
/// </summary>
abstract class Animal
{
    private static readonly Dictionary<int, IAnimalCreator> _creatorMap = new();

    public abstract int Type { get; }
    public abstract string Name { get; }

    public static Animal Create(int type)
    {
        var bResult = _creatorMap.TryGetValue(type, out var creator);
        if (bResult is false)
            throw new NotImplementedException($"Type({type}) Animal creator not found.");

        return creator!.Create();
    }

    public static void AddCreator(IAnimalCreator creator) => _creatorMap[creator.Type] = creator;
}

/// <summary>
/// 인스턴스 생성자 인터페이스
/// </summary>
interface IAnimalCreator
{
    int Type { get; }

    Animal Create();
}

/// <summary>
/// Animal이 Animal 구현체를 직접 바라보지 않도록 제네릭으로 인터페이스 구현
/// </summary>
/// <typeparam name="TAnimal"></typeparam>
class AnimalCreator<TAnimal> : IAnimalCreator
    where TAnimal : Animal, IHaveType, new()
{
    public int Type => TAnimal.AnimalType;
    
    public Animal Create() => new TAnimal();
}

interface IHaveType
{
    static abstract int AnimalType { get; }
}

/// <summary>
/// Animal <- Dog
/// </summary>
class Dog : Animal, IHaveType
{
    public static int AnimalType => 1;

    public override int Type => AnimalType;

    public override string Name => "Dog";
}

/// <summary>
/// Animal <- Cat
/// </summary>
class Cat : Animal, IHaveType
{
    public static int AnimalType => 2;

    public override int Type => AnimalType;

    public override string Name => "Cat";
}

/// <summary>
/// Animal <- Pig
/// </summary>
class Pig : Animal, IHaveType
{
    public static int AnimalType => 3;

    public override int Type => AnimalType;

    public override string Name => "Pig";
}


