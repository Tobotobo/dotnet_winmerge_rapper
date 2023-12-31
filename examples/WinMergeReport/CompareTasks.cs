using System.Collections.Concurrent;

namespace com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

public class CompareTasks : List<CompareTask>
{
    // 完了したタスクの数
    public int CompletedCount { get; private set; }

    private int _currentTaskIndex = 0;

    public List<CompareTask> RunningTasks { get; } = [];

    public Task Start(int thredCount = 1)
    {
        CompletedCount = 0;
        _currentTaskIndex = 0;
        RunningTasks.Clear();

        return Task.Run(() =>
        {
            while (true)
            {
                var completedTasks = RunningTasks.Where(task => task.IsCompleted).ToList();
                foreach (var completedTask in completedTasks)
                {
                    RunningTasks.Remove(completedTask);
                    CompletedCount += 1;
                }
                while (RunningTasks.Count < thredCount && _currentTaskIndex < this.Count)
                {
                    var task = this[_currentTaskIndex];
                    _currentTaskIndex += 1;
                    RunningTasks.Add(task);
                    task.Start();
                }
                Thread.Sleep(100);
                if (CompletedCount >= this.Count)
                {
                    break;
                }
            }
        });

        // var tasks = this.Select(compareTask => Task.Run(() => compareTask.CompareFile)).ToArray();
        // var progress = new Progress(tasks.Length);
        // progress.Start();
        // while (tasks.Any(task => !task.IsCompleted))
        // {
        //     var completedTask = Task.WaitAny(tasks);
        //     tasks[completedTask].IsCompleted = true;
        //     progress.Value++;
        //     progress.Update();
        // }
        // progress.Stop();
    }

}