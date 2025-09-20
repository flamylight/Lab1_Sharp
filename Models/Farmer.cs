namespace Models;

public class Farmer: Person, ISwim
{
    public int Age { get; }
    
    public Farmer(string name, string lastName, string age):base(name, lastName)
    {
        Age = int.Parse(age);
    }

    public Farmer(List<KeyValue> args)
        : base(GetValue(args, "firstname"), GetValue(args, "lastname"))
    {
        
        bool check = int.TryParse(GetValue(args, "age"), out int age);

        if (!check)
        {
            throw new ArgumentException("Invalid age, age must be a number!");
        }
        
        Age = age;
    }

    public string Swim()
    {
        return "I can swim.";
    }

    public override string ToString()
    {
        return $"{Name} {LastName}, {Age}. Other: {Swim()}";
    }

    public override string ToBlock()
    {
        return $"Farmer {Name}{LastName}\n" +
               $"{{ \"firstname\": {Name},\n" +
               $"\"lastname\": \"{LastName}\",\n" +
               $"\"age\": {Age}}};";
    }
}