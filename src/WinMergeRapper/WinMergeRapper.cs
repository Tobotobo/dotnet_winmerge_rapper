using System;
using System.Diagnostics;

namespace com.github.Tobotobo.DotnetWinMergeRapper;

public class WinMergeRapper(string winMergeUExePath)
{
    public string WinMergeUExePath { get; set; } = winMergeUExePath;
    public CommandLineOptions CommandLineOptions { get; set; } = new CommandLineOptions();
    public IniFileSettings? IniFileSettings { get; set; } = null;

    public Process Start()
    {
        var copiedCommandLineOptions = CommandLineOptions with { };
        return Start_(WinMergeUExePath, copiedCommandLineOptions, IniFileSettings);
    }

    public Process Start(string leftPath, string rightPath)
    {
        ArgumentNullException.ThrowIfNull(leftPath);
        ValidatePath(leftPath);
        ArgumentNullException.ThrowIfNull(rightPath);
        ValidatePath(rightPath);

        var copiedCommandLineOptions = CommandLineOptions with
        {
            LeftPath = leftPath,
            RightPath = rightPath,
        };

        return Start_(WinMergeUExePath, copiedCommandLineOptions, IniFileSettings);
    }

    public static Process Start(
        string winMergeUExePath,
        CommandLineOptions? commandLineOptions = null,
        IniFileSettings? iniFileSettings = null)
    {
        var copiedCommandLineOptions =
            commandLineOptions == null ? new CommandLineOptions() : commandLineOptions with { };
        var process = Start_(winMergeUExePath, copiedCommandLineOptions, iniFileSettings);
        return process;
    }

    private static Process Start_(
        string winMergeUExePath,
        CommandLineOptions commandLineOptions,
        IniFileSettings? iniFileSettings
    )
    {
        ArgumentNullException.ThrowIfNull(winMergeUExePath);
        if (!File.Exists(winMergeUExePath))
        {
            throw new FileNotFoundException(winMergeUExePath);
        }

        string? tempIniFile = null;
        if (iniFileSettings != null)
        {
            if (commandLineOptions.IniFile == null)
            {
                tempIniFile = Path.GetTempFileName();
                commandLineOptions.IniFile = tempIniFile;
            }
            iniFileSettings.SaveToFile(commandLineOptions.IniFile);
        }

        var winMergeArguments = commandLineOptions.ToArguments();

        var startInfo = new ProcessStartInfo
        {
            FileName = winMergeUExePath,
            Arguments = winMergeArguments,
            WorkingDirectory = Environment.CurrentDirectory,
        };

        var process = Process.Start(startInfo)!;

        process.Disposed += (sender, e) =>
        {
            if (tempIniFile != null)
            {
                File.Delete(tempIniFile);
            }
        };

        return process;
    }

    private static void ValidatePath(string path)
    {
        if (!File.Exists(path) && !Directory.Exists(path))
        {
            var extension = Path.GetExtension(path);
            if (String.IsNullOrEmpty(extension))
            {
                throw new DirectoryNotFoundException(path);
            }
            else
            {
                throw new FileNotFoundException(path);
            }
        }
    }
}
