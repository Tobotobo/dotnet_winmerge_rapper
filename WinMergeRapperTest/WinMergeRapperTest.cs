using com.github.Tobotobo.DotnetWinMergeRapper;

namespace com.github.Tobotobo.DotnetWinMergeRapperTest;

public class WinMergeRapperTest
{
    [Fact]
    public void Test1()
    {
        var arguments = new CommandLineArguments
        {
            Minimize = true,
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