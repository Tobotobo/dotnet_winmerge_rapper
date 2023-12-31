namespace com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

public class CompareTask : Task
{
    public CompareFile CompareFile { get; set; }

    // // 完了したかどうか
    // public bool IsCompleted { get; set; } = false;

    public CompareTask(CompareFile compareFile, Action action) : base(action)
    {
        CompareFile = compareFile;
    }
}