
Dog d1 = new Dog("King", 25);
Dog d2 = new Dog("Tiny", 95);
Dog d3 = new Dog("Rufus", 36);
Dog d4 = new Dog("Spot", 55);
Dog d5 = new Dog("Daisy", 8);
Dog d6 = new Dog("Ivan", 499);
List<Dog> dogs = new List<Dog> { d1, d2, d3, d4, d5, d6 };


// Print out all Dogs with a weight larger than 40 kg.
Predicate<Dog> HeavierThan40Kg = d => d.Weight > 40;
//Console.WriteLine("\nPrint out all dogs lighter than 40kg:");
//Console.WriteLine("Condinional print called with predicate ((Dog d) => d.Weight > 40)");
//ConditionalPrint(dogs, HeavierThan40Kg);

//// Print out all Dogs with a weight smaller than Rufus' weight.
//Predicate<Dog> LighterThanRufus = d => d.Weight < d3.Weight;
//Console.WriteLine("\nPrint out all dogs lighter than Rufus:");
//Console.WriteLine("Condinional print called with predicate ((Dog d) => d.Weight < d3.Weight)");
//ConditionalPrint(dogs, LighterThanRufus);

//// Print out all Dogs with a name that contains an "i"
Predicate<Dog> NameContainsI = d => d.Name.Contains('i', StringComparison.OrdinalIgnoreCase);
//Console.WriteLine("\nPrint out all dogs with 'i' in the name:");
//Console.WriteLine("Condinional print called with predicate ((Dog d) => d.Name.Contains('i')");
//ConditionalPrint(dogs, NameContainsI);

List<Predicate<Dog>> predList = new List<Predicate<Dog>> { HeavierThan40Kg, NameContainsI };

//static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
//{
//    Console.WriteLine();
//    foreach (var item in objects.FindAll(pred))
//    {
//        Console.WriteLine(item);
//    }
//}


//static void ConditionalPrint2a<T>(List<T> objects, Predicate<T> pred1, Predicate<T> pred2)
//{
//    Console.WriteLine();
//    foreach (var item in objects.FindAll(pred1).FindAll(pred2))
//    {
//        Console.WriteLine(item);
//    }
//}


//static void ConditionalPrint2b<T>(List<T> objects, Predicate<T> pred1, Predicate<T> pred2)
//{
//    Console.WriteLine();
//    foreach (var item in objects.FindAll(pred1))
//    {
//        if (pred2(item))
//            Console.WriteLine(item);
//    }
//}

//static void ConditionalPrint2c<T>(List<T> objects, Predicate<T> pred1, Predicate<T> pred2)
//{
//    Console.WriteLine();
//    foreach (var item in objects)
//    {
//        if (pred1(item) && pred2(item))
//        {
//            Console.WriteLine(item);
//        }
//    }
//}


MultiConditionalPrint(dogs, predList);


static void MultiConditionalPrint<T>(List<T> objects, List<Predicate<T>> predicates)
{
    int filters = predicates.Count;
    List<T> results = new List<T>();

    foreach (var item in objects.FindAll(predicates[0]))
    {
        results.Add(item);
    }

    if (filters > 1) {
        for (int i = 1; i < filters; i++)
        {
            List<T> r = new List<T>();
            foreach (var item in results.FindAll(predicates[i]))
            {
                r.Add(item);

            }
            results = r;
            r.Clear();
        }
    }
    foreach (var item in results)
    {
        Console.WriteLine(item);
    }
}

