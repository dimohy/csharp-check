﻿using MemoryPack;

Console.WriteLine("!");



[MemoryPackable]
public partial class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
}