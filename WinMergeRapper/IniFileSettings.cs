using System.Text;

namespace com.github.Tobotobo.DotnetWinMergeRapper;

public class IniFileSettings : Dictionary<string, IniFileSetting>
{
    private static readonly Encoding ENCODING_SHIFT_JIS;

    static IniFileSettings()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        ENCODING_SHIFT_JIS = Encoding.GetEncoding(932);
    }

    public IniFileSetting Add(string name, string value)
    {
        var setting = new IniFileSetting(name, value);
        Add(name, setting);
        return setting;
    }

    public IniFileSetting Add(string name)
    {
        var setting = new IniFileSetting(name);
        Add(name, setting);
        return setting;
    }

    public IniFileSetting Add(IniFileSetting setting)
    {
        Add(setting.Name, setting);
        return setting;
    }

    private new void Add(string name, IniFileSetting setting) => base.Add(name, setting);

    public void AddRange(IEnumerable<IniFileSetting> settings)
    {
        foreach (var setting in settings)
        {
            Add(setting);
        }
    }

    public void SaveToFile(string path)
    {
        File.WriteAllText(path, ToString(), ENCODING_SHIFT_JIS);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("[WinMerge]");
        foreach (var setting in this.Select(x => x.Value))
        {
            sb.AppendLine($"{setting.Name}={setting.Value}");
        }

        return sb.ToString();
    }
}