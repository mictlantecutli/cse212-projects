public class Person
{
    public readonly string Name;

    public int Turns { get; set; }
    public bool IsInfinite { get; }

    internal Person(string name, int turns)
    {
        Name = name;
        //It is when a person get 0 it is converted to 1
        Turns = turns > 0 ? turns : 1;
        //The turns are infinite when the user set 0 or negative number
        //It is a boolean
        IsInfinite = turns <= 0;

    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}