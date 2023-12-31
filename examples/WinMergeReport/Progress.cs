using System.Diagnostics.Metrics;

namespace com.github.Tobotobo.DotnetWinMergeRapper.WinMergeReport;

public class Progress(int maxValue)
{
    private static readonly String[] spinner = ["⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏"];

    private int _spinnerIndex = 0;

    public int CursorTop { get; set; } = Console.CursorTop;
    public int CursorLeft { get; set; } = Console.CursorLeft;

    public int Value { get; set; } = 0;

    public int MaxValue { get; set; } = maxValue;
    public int MaxProgreessCount { get; set; } = 30;

    // ヘッダー
    public Action<Progress, bool>? Header { get; set; }

    // フッター
    public Action<Progress, bool>? Footer { get; set; }

    public Action<Progress>? Update { get; set; }

    private Task? _task;

    public void Start()
    {
        _task = Task.Run(() =>
        {
            Console.CursorVisible = false;
            while (Value < MaxValue)
            {
                // Console.Clear();
                // カーソル位置を先頭に戻す
                // Console.SetCursorPosition(CursorLeft, CursorTop);
                Console.SetCursorPosition(0, 0);
                if (Update != null)
                {
                    Update(this);
                }
                if (Header != null)
                {
                    Header(this, false);
                }
                Update_();
                if (Footer != null)
                {
                    Footer(this, false);
                }
                Thread.Sleep(100);
            }
            // Console.SetCursorPosition(CursorLeft, CursorTop);
            Console.SetCursorPosition(0, 0);
            if (Header != null)
            {
                Header(this, true);
            }
            Update_();
            if (Footer != null)
            {
                Footer(this, true);
            }
            Console.CursorVisible = true;
        });
    }




    private void Update_()
    {
        // スピナー
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(spinner[_spinnerIndex++ % spinner.Length]);
            Console.ResetColor();
        }

        // プログレスバー
        {
            var progress = Value * MaxProgreessCount / MaxValue;
            Console.Write(" [");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(new String('█', progress));
            Console.ResetColor();
            Console.Write(new String('.', MaxProgreessCount - progress));
            Console.Write("]");
            Console.ResetColor();
        }

        // パーセンテージ
        {
            Console.Write($" {Value * 100 / MaxValue}%");
        }

        // 現在値
        {
            Console.Write($" ({Value}/{MaxValue})");
        }
    }
}