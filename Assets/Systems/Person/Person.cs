public class Person
{
    public string Name { get; }
    public Stats Stats { get; }

    public Person(string name, Stats stats)
    {
        Name = name;
        Stats = stats;
    }
}
