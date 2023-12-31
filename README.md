# dotnet_winmerge_rapper

試行錯誤なぅ

```
dotnet new gitignore
dotnet new sln -n WinMergeRapper
dotnet new classlib -o ./WinMergeRapper
dotnet sln add ./WinMergeRapper
dotnet new xunit -o ./WinMergeRapperTest
dotnet sln add ./WinMergeRapperTest
dotnet add ./WinMergeRapperTest reference ./WinMergeRapper
```

コマンドライン - WinMerge 2.16 ヘルプ  
https://manual.winmerge.org/jp/Command_line.html

```
dotnet new console -o ./examples/WinMergeReport
dotnet add ./examples/WinMergeReport reference ./src/WinMergeRapper
```

```
dotnet run --project ./examples/WinMergeReport
dotnet publish ./examples/WinMergeReport
```

Publish Native AOT using the CLI  
https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/?tabs=net8plus%2Cwindows

プロジェクトが複数ある状態で特定のプロジェクトのインテリセンス等を有効にするには？  
コマンドパレット(Ctrl+Shift+P) → OmniSharp: プロジェクトの選択