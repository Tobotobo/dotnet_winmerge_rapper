using com.github.Tobotobo.DotnetWinMergeRapper;

namespace com.github.Tobotobo.DotnetWinMergeRapperTest;

public class WinMergeRapperTest
{
    [Fact]
    public void Test3()
    {
        var commandLineOptions = new CommandLineOptions
        {
            // E = true,
            // Minimize = true,
            // NonInteractive = true,
            // U = true,
            // OR = @"C:\新しいフォルダー\output.htm",
            // LeftPath = @"C:\新しいフォルダー\aaa\aaa.xlsx",
            // RightPath = @"C:\新しいフォルダー\bbb\aaa.xlsx",
        };

        var iniFileSettings = new IniFileSettings
        {
            { "Settings/ScrollToFirst", "1" },
        };

        var process = WinMergeRapper.Start(commandLineOptions, iniFileSettings);
        process.WaitForExit();
    }

    [Fact]
    public void Test1()
    {
        // var options = new CommandLineOptions
        // {
        //     E = true,
        //     Minimize = true,
        //     NonInteractive = true,
        //     U = true,
        //     OR = @"C:\新しいフォルダー\output.htm",
        //     LeftPath = @"C:\新しいフォルダー\aaa\aaa.xlsx",
        //     RightPath = @"C:\新しいフォルダー\bbb\aaa.xlsx",
        // };

        // Console.WriteLine($"argumets = {options.ToArguments()}");

        // var process = WinMergeRapper.Start(options);
        var process = WinMergeRapper.Start();
        process.WaitForExit();
    }

    [Fact]
    public void Test2()
    {
        var iniFileSettings = new IniFileSettings
        {
            { "Test", "123" },
            { "aaa", "456" },
        };
        Console.WriteLine(iniFileSettings.ToString());
    }
}