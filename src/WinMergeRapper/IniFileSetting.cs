namespace com.github.Tobotobo.DotnetWinMergeRapper;

public class IniFileSetting
{
    public string Name { get; }

    public string Value { get; set; }


    public IniFileSetting(string name) : this(name, "") { }

    public IniFileSetting(string name, string value)
    {
        Name = name;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Name}={Value}";
    }
}