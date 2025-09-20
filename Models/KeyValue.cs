namespace Models;

public struct KeyValue
{
    public string Key { get; }
    public string Value { get; }

    public KeyValue(string key, string value)
    {
        Key = key;
        Value = value;
    }
}