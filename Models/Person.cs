namespace Models;

public abstract class Person
{
    public string Name { get;  }
    public string LastName { get; }

    public Person(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    
    public static string GetValue(List<KeyValue> keyValues, string key)
    {
        for (int i = 0; i < keyValues.Count; i++)
        {
            if (keyValues[i].Key == key)
            {
                return keyValues[i].Value;
            }
        }

        throw new KeyNotFoundException($"Key {key} not found");
    }

    abstract public string ToBlock();
}