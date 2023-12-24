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