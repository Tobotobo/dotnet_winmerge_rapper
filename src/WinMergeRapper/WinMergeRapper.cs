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
        return Start(WinMergeUExePath, CommandLineOptions, IniFileSettings);
    }

    public Process Create()
    {
        return Create(WinMergeUExePath, CommandLineOptions, IniFileSettings);
    }

    public Process Start(string leftPath, string rightPath)
    {
        var process = Create(leftPath, rightPath);
        process.Start();
        return process;
    }

    public Process Create(string leftPath, string rightPath)
    {
        ValidatePath(leftPath, nameof(leftPath));
        ValidatePath(rightPath, nameof(rightPath));

        var copiedCommandLineOptions = CommandLineOptions with
        {
            LeftPath = leftPath,
            RightPath = rightPath,
        };

        return Create(WinMergeUExePath, copiedCommandLineOptions, IniFileSettings);
    }

    public static Process Start(
        string winMergeUExePath,
        CommandLineOptions? commandLineOptions = null,
        IniFileSettings? iniFileSettings = null)
    {
        var process = Create(winMergeUExePath, commandLineOptions, iniFileSettings);
        process.Start();
        return process;
    }

    public static Process Create(
        string winMergeUExePath,
        CommandLineOptions? commandLineOptions = null,
        IniFileSettings? iniFileSettings = null)
    {
        ValidateFilePath(winMergeUExePath, nameof(winMergeUExePath));

        var copiedCommandLineOptions =
            commandLineOptions == null ? new CommandLineOptions() : commandLineOptions with { };

        string? tempIniFile = null;
        if (iniFileSettings != null)
        {
            if (copiedCommandLineOptions.IniFile == null)
            {
                tempIniFile = Path.GetTempFileName();
                copiedCommandLineOptions.IniFile = tempIniFile;
            }
            iniFileSettings.SaveToFile(copiedCommandLineOptions.IniFile);
        }

        var startInfo = new ProcessStartInfo
        {
            FileName = winMergeUExePath,
            Arguments = copiedCommandLineOptions.ToArguments(),
        };

        var process = new Process
        {
            StartInfo = startInfo,
        };
        process.Disposed += (sender, e) =>
        {
            if (tempIniFile != null)
            {
                File.Delete(tempIniFile);
            }
        };

        return process;
    }

    private static void ValidatePath(string path, string paramName)
    {
        ArgumentNullException.ThrowIfNull(path, paramName);
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

    private static void ValidateFilePath(string path, string paramName)
    {
        ArgumentNullException.ThrowIfNull(path, paramName);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException(path);
        }
    }
}
