using com.github.Tobotobo.DotnetWinMergeRapper;

namespace com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

public class App
{

    public void Run()
    {
        // var winMerge = new WinMergeRapper(Path.Combine(Environment.GetEnvironmentVariable("WINMERGE_PATH") ?? "", "WinMergeU.exe"));

        // winMerge.Start().WaitForExit();




        // 指定したフォルダの中にあるファイルの一覧を取得する
        var leftPath = Path.Combine(Environment.CurrentDirectory, "TestData", "a");
        var rightPath = Path.Combine(Environment.CurrentDirectory, "TestData", "b");


        Action<string, Action<string, string>> dumpFiles = (path, action) =>
        {
            var files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                action(path, file);
            }
        };

        var compareFiles = new CompareFiles();

        dumpFiles(leftPath, (basePath, fullPath) =>
        {
            compareFiles.AddLeft(basePath, fullPath);
        });
        dumpFiles(rightPath, (basePath, fullPath) =>
        {
            compareFiles.AddRight(basePath, fullPath);
        });

        foreach (var compareFile in compareFiles.Values)
        {
            Console.WriteLine(compareFile);
        }
    }


    // string GetRelativePath(string uri1, string uri2)
    // {
    //     var u1 = new Uri(uri1);
    //     var u2 = new Uri(uri2);
    //     var relativeUri = u1.MakeRelativeUri(u2);
    //     var relativePath = relativeUri.ToString();
    //     var index = relativePath.IndexOf('/');
    //     if (index == -1) return relativePath;
    //     relativePath = relativePath.Substring(index + 1);
    //     return relativePath;
    // }

}



