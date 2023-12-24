using System;
using System.Diagnostics;

namespace com.github.Tobotobo.DotnetWinMergeRapper;

public static class WinMergeRapper
{
    public static Process Start(CommandLineArguments arguments)
    {
        var winMergePath = @"C:/winmerge-2.16.36-x64-exe/WinMerge/WinMergeU.exe";
        var winMergeArguments = arguments.ToString();

        var process = Process.Start(winMergePath, winMergeArguments);

        return process;
    }
    // {
    //     var winMergePath = @"C:/winmerge-2.16.36-x64-exe/WinMerge/WinMergeU.exe";
    //     var winMergeArguments = ""; //$"\"{file1}\" \"{file2}\"";

    //     // var process = new Process
    //     // {
    //     //     StartInfo =
    //     //     {
    //     //         FileName = winMergePath,
    //     //         Arguments = winMergeArguments,
    //     //         UseShellExecute = false,
    //     //         RedirectStandardOutput = true,
    //     //         RedirectStandardError = true,
    //     //         CreateNoWindow = true
    //     //     }
    //     // };

    //     var process = Process.Start(winMergePath, winMergeArguments);

    //     // process.Start();
    //     process.WaitForExit();

    //     var exitCode = process.ExitCode;
    //     if (exitCode != 0)
    //     {
    //         Console.WriteLine($"WinMerge exited with code {exitCode}");
    //     }
    // }


    // private static void Main(string[] args)
    // {
    //     if (args.Length != 2)
    //     {
    //         Console.WriteLine("Usage: WinMergeRapper.exe file1 file2");
    //         return;
    //     }

    //     var file1 = args[0];
    //     var file2 = args[1];

    //     var winMergePath = @"C:\Program Files (x86)\WinMerge\WinMergeU.exe";
    //     var winMergeArguments = $"\"{file1}\" \"{file2}\"";

    //     var process = new Process
    //     {
    //         StartInfo =
    //         {
    //             FileName = winMergePath,
    //             Arguments = winMergeArguments,
    //             UseShellExecute = false,
    //             RedirectStandardOutput = true,
    //             RedirectStandardError = true,
    //             CreateNoWindow = true
    //         }
    //     };

    //     process.Start();
    //     process.WaitForExit();

    //     var exitCode = process.ExitCode;
    //     if (exitCode != 0)
    //     {
    //         Console.WriteLine($"WinMerge exited with code {exitCode}");
    //     }
    // }
}
