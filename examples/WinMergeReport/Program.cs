

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Reflection;
using System.Text;
using com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

// コンソールの出力エンコーディングをUTF-16に設定
Console.OutputEncoding = Encoding.Unicode;
Console.Clear();

// new App().Run();

// var bars = new[] { "－", "／", "－", "＼" };
// var spinner = new[] { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" };

// Console.Write("進捗を表示します。");
// var top = Console.CursorTop;
// var left = Console.CursorLeft;

var compareFiles = new CompareFiles();
foreach (var i in Enumerable.Range(1, 30))
{
    var compareFile = new CompareFile($"fiあle{i}.txt");
    compareFiles.Add(compareFile.RelativePath, compareFile);
}

var compareTasks = new CompareTasks();
var random = new Random();
foreach (var compareFile in compareFiles.Values)
{
    compareTasks.Add(new CompareTask(compareFile, () => Thread.Sleep(500 + random.Next(1000))));
}


var progress = new Progress(compareTasks.Count);
progress.Update = (p) =>
{
    p.Value = compareTasks.CompletedCount;
};
// progress.Header = (p) =>
// {
//     Console.Write("処理中...");
// };
int maxTasks = 0;
int maxLength = 0;
progress.Footer = (p, completed) =>
{
    if (completed)
    {
        return;
    }
    if (maxTasks < compareTasks.RunningTasks.Count)
    {
        maxTasks = compareTasks.RunningTasks.Count;
    }
    Console.WriteLine("");
    foreach (var compareTask in compareTasks.RunningTasks)
    {
        var relativePath = compareTask.CompareFile.RelativePath;
        if (maxLength < relativePath.Length)
        {
            maxLength = relativePath.Length;
        }
        Console.WriteLine($"{relativePath}");
    }
    foreach (var i in Enumerable.Range(1, maxTasks - compareTasks.RunningTasks.Count))
    {
        Console.WriteLine(new string(' ', maxLength * 2));
    }
};
progress.Start();


compareTasks.Start(10).Wait();

Thread.Sleep(1000);












// task.Wait();


// int value;

// var maxProgreess = 30;
// foreach (value in Enumerable.Range(1, maxValue))
// {
//     progress.Value = value;
//     progress.Update();

//     Thread.Sleep(50);
// }
// Console.WriteLine(" 完了");

// Console.CursorVisible = false;

// for (var i = 0; i < 10; i++)
// {

//     Console.WriteLine(bars[i % bars.Length]);
//     Console.SetCursorPosition(0, Console.CursorTop);
//     System.Threading.Thread.Sleep(300);
// }

// Console.CursorVisible = true;

