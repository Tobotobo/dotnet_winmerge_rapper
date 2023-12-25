using com.github.Tobotobo.DotnetWinMergeRapper;

namespace com.github.Tobotobo.DotnetWinMergeRapperTest;

public class WinMergeRapperTest
{
    [Fact]
    public void Test1()
    {
        var arguments = new CommandLineArguments
        {
            E = true,
            Minimize = true,
            NonInteractive = true,
            U = true,
            OR = @"C:\新しいフォルダー\output.htm",
            LeftPath = @"C:\新しいフォルダー\aaa\aaa.xlsx",
            RightPath = @"C:\新しいフォルダー\bbb\aaa.xlsx",
        };

        Console.WriteLine($"argumets = {arguments}");

        var process = WinMergeRapper.Start(arguments);
        process.WaitForExit();
    }

    // [Fact]
    // public void Test2()
    // {
    //     var winMerge = new WinMergeRapper();
    //     winMerge.Run();
    // }
}