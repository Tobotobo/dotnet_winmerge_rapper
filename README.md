# dotnet_winmerge_rapper

（注意！）試行錯誤中。突然大きく改変される可能性あり！

## 概要
WinMerge (※) の実行ファイルを C# から簡便に実行できるラッパーを作成する。

※ winmerge-2.16.36-x64-exe

## 参考

コマンドライン - WinMerge 2.16 ヘルプ  
https://manual.winmerge.org/jp/Command_line.html

## 調査記録

設定がどのように保存されているか調査する #3  
https://github.com/Tobotobo/dotnet_winmerge_rapper/issues/3

## 環境構築

```
dotnet new gitignore
dotnet new sln -n ./src/WinMergeRapper
dotnet new classlib -o ./src/WinMergeRapper
dotnet sln add ./src/WinMergeRapper
dotnet new xunit -o ./src/WinMergeRapperTest
dotnet sln add ./src/WinMergeRapperTest
dotnet add ./src/WinMergeRapperTest reference ./src/WinMergeRapper
```

ビルド
```
dotnet build ./src/WinMergeRapper -c Release
```

## 使い方

WinMergeRapper.dll かプロジェクトフォルダごと持って行って、使いたいプロジェクトから参照する。  
(いつか nuget のパッケージにできたらいいな)

※ src/WinMergeRapperTest に動くコードがあるので詳細はそっち見て

使用例１）WinMerge を起動して a フォルダと b フォルダの比較結果を表示
```cs
var winMerge = new WinMergeRapper("C:/WinMerge/WinMergeU.exe");
winMerge.Start("./TestData/a", "./TestData/b").WaitForExit();
```

使用例２）a フォルダと b フォルダの比較結果を output.html に出力して終了
```cs
var winMergeUExePath = @"C:\WinMerge\WinMergeU.exe";

var commandLineOptions = new CommandLineOptions
{
    E = true,
    Minimize = true,
    NonInteractive = true,
    U = true,
    OR = "./Report/output.html",
    LeftPath = "./TestData/a",
    RightPath = "./TestData/b",
    EnableExitCode = true,
};

var iniFileSettings = new IniFileSettings
{
    { "ReportFiles/IncludeFileCmpReport", "1" },
    { "ReportFiles/ReportType", "2" },
    { "Settings/DirViewExpandSubdirs", "1" },
};

WinMergeRapper.Start(
        winMergeUExePath,
        commandLineOptions,
        iniFileSettings)
    .WaitForExit();
```