using System.Diagnostics;
using com.github.Tobotobo.DotnetWinMergeRapper;

namespace com.github.Tobotobo.DotnetWinMergeRapperTest;

public class WinMergeRapperTest
{
    [Fact]
    public void Test1()
    {
        var winMerge = new WinMergeRapper(Path.Combine(Environment.GetEnvironmentVariable("WINMERGE_PATH") ?? "", "WinMergeU.exe"));

        Debug.WriteLine(Environment.CurrentDirectory);

        var a = "../../../TestData/a";
        var b = "../../../TestData/b";

        winMerge.Start(a, b).WaitForExit();
    }

    [Fact]
    public void Test2()
    {
        var winMergeUExePath = Path.Combine(Environment.GetEnvironmentVariable("WINMERGE_PATH") ?? "", "WinMergeU.exe");
        var a = "../../../TestData/a";
        var b = "../../../TestData/b";
        var reportDir = "../../../Report";
        var output = Path.Combine(reportDir, "output.html");

        // reportDir を削除して作り直す
        if (Directory.Exists(reportDir))
        {
            Directory.Delete(reportDir, true);
        }
        Directory.CreateDirectory(reportDir);

        var commandLineOptions = new CommandLineOptions
        {
            E = true,
            Minimize = true,
            NonInteractive = true,
            U = true,
            OR = output,
            LeftPath = a,
            RightPath = b,
            EnableExitCode = true,
        };

        var iniFileSettings = new IniFileSettings
        {
            { "ReportFiles/IncludeFileCmpReport", "1" },
            { "ReportFiles/ReportType", "2" },
            { "Settings/DirViewExpandSubdirs", "1" },
        };

        var process = WinMergeRapper.Start(
            winMergeUExePath,
            commandLineOptions,
            iniFileSettings);

        process.WaitForExit();

        // EnableExitCode が有効な場合
        // 0: 差分なし, 1: 差分あり, 2: エラー
        // ※レポートが出力できなくても比較に成功するとエラーにならないので注意
        if (process.ExitCode == 2)
        // if (process.ExitCode != 0)
        {
            throw new Exception($"WinMerge exited with code {process.ExitCode}");
        }
    }
}