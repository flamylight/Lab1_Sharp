namespace Models;

public class Painter: Person, IDraw
{
    public string Style { get; set; }

    public Painter(string name, string lastName, string style) : base(name, lastName)
    {
        Style = style;
    }

    public Painter(List<KeyValue> args)
        :base(GetValue(args, "firstname"),GetValue(args, "lastname"))
    {
        Style = GetValue(args, "style");
    }

    public string Draw()
    {
        return "I draw beautiful pictures.";
    }

    public override string ToString()
    {
        return $"Painter {Name} {LastName}, {Style}. Other: {Draw()}";
    }

    public override string ToBlock()
    {
        return $"Painter {Name}{LastName}\n" +
               $"{{ \"firstname\": {Name},\n" +
               $"\"lastname\": \"{LastName}\",\n" +
               $"\"style\": {Style}}};";
    }
}