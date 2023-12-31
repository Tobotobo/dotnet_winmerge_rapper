namespace com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

public class CompareFile
{
    public CompareFile(string relativePath)
    {
        RelativePath = relativePath;
    }

    public string RelativePath { get; }
    public string? LeftPath { get; set; } = null;
    public string? RightPath { get; set; } = null;

    public bool LeftExists { get => LeftPath != null; }
    public bool RightExists { get => RightPath != null; }

    public override string ToString()
    {
        return $"{(LeftExists ? "L" : " ")}{(RightExists ? "R" : " ")}:{RelativePath}";
    }
}