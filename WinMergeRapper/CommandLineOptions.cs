namespace com.github.Tobotobo.DotnetWinMergeRapper;

public class CommandLineOptions : ICloneable
{
    // コマンドライン - WinMerge 2.16 ヘルプ
    // https://manual.winmerge.org/jp/Command_line.html

    /// <summary>
    /// /r
    /// すべてのサブフォルダー内のすべてのファイルを比較します(再帰比較)。 ユニークフォルダー (片方のみ存在するフォルダー)は、分離された項目として比較結果内にリストされます。 サブフォルダーまで含めるとかなり比較時間が増大してしまうことに注意してください。 このパラメーターを指定しなかった場合、WinMergeは比較するフォルダー内のファイルとトップレベルのサブフォルダーのみリストします。 サブフォルダーの中までは比較しません。
    /// </summary>
    /// <value></value>
    public bool R { get; set; } = false;

    public string RToArgument { get => R ? "/r" : ""; }

    /// <summary>
    /// /e
    /// EscキーでWinMergeが閉じるようにします。 WinMergeを外部比較アプリケーションとして使用する場合に便利です。 (ダイアログのようにすばやくWinMergeを閉じることができます) この引数を指定しなかった場合、すべてのウインドウを閉じるのに何回もEscキーを 押さなければならないことになるかもしれません。(2つ以上タブが開かれている場合、一回のESCキーの押下でWinMergeが終了してしまうのを期待している人はいないような気がしたので、日本語版ではこのオプションを指定しても2つ以上タブが開かれている場合は1つのタブを閉じるだけにし、タブが1つの時またはタブが一つもない時にWinMergeを終了するようにしました)
    /// </summary>
    /// <value></value>
    public bool E { get; set; } = false;

    public string EToArgument { get => E ? "/e" : ""; }

    /// <summary>
    /// /f
    /// 比較を制限するために、指定したフィルターを適用します。 フィルターは*.h *.cppのようなファイルマスクか、 XML/HTML Develのようなファイルフィルターの名前です。 スペースを含むフィルターマスクやフィルター名はダブルクォーテーションマークで括ってください。
    /// </summary>
    /// <value></value>
    public string? F { get; set; } = null;

    public string FToArgument { get => F == null ? "" : $"/f \"{F}\""; }

    /// <summary>
    /// /m compare-method
    /// フォルダー比較方法を指定します。 次のキーワードが指定できます。Full, Quick, Binary, Date, SizeDate Size
    /// </summary>
    /// <value></value>
    public CompareMethod M { get; set; } = CompareMethod.Default;

    public string MToArgument { get => M == CompareMethod.Default ? "" : $"/m {M}"; }

    /// <summary>
    /// /t window-type
    /// ファイルを表示するウインドウの種類を指定します。 次のキーワードが指定できます。 Text, Table, Binary, Image, Webpage
    /// </summary>
    /// <value></value>
    public WindowType T { get; set; } = WindowType.Default;

    public string TToArgument { get => T == WindowType.Default ? "" : $"/t {T}"; }

    /// <summary>
    /// /x
    /// 同一ファイルの比較をしたときにWinMergeを閉じます。 (情報ダイアログを表示した後) このパラメーターは比較後に効果がなくなります。 例えば、もしファイルがマージか編集の結果として同一となった場合です。 このパラメーターは、WinMergeを外部アプリケーションとして使用したり、 差異のないファイルを無視することによって余分なステップを取り除きたい場合に便利です。
    /// </summary>
    /// <value></value>
    public bool X { get; set; } = false;

    public string XToArgument { get => X ? "/x" : ""; }

    /// <summary>
    /// /xq
    /// オプション /x に似ていますが、同一ファイルであってもメッセージボックスを表示しません。
    /// </summary>
    /// <value></value>
    public bool XQ { get; set; } = false;

    public string XQToArgument { get => XQ ? "/xq" : ""; }

    /// <summary>
    /// /s
    /// WinMergeウインドウを1つのインスタンスに制限します。 例えば、WinMergeが既に実行中ならば、新しい比較は同じインスタンス内で実行されます。 この引数を指定しなかった場合、複数のウインドウが開かれる可能性があります: 設定によっては、新しい比較が既に存在するウインドウで実行されることも新しいウインドウで 実行されることもあります。
    /// </summary>
    /// <value></value>
    public bool S { get; set; } = false;

    public string SToArgument { get => S ? "/s" : ""; }

    /// <summary>
    /// /sw
    /// /s と同様にWinMergeウインドウを1つのインスタンスに制限します。 ただし、ウインドウを表示しているインスタンスが終了するまで待機します。
    /// </summary>
    /// <value></value>
    public bool SW { get; set; } = false;

    public string SWToArgument { get => SW ? "/sw" : ""; }

    /// <summary>
    /// /s-
    /// "複数のインスタンスを起動しない"の設定値を無視して、 常に別のインスタンスが起動されるようにします。
    /// </summary>
    /// <value></value>
    public bool S_ { get; set; } = false;

    public string S_ToArgument { get => S_ ? "/s-" : ""; }

    /// <summary>
    /// /ul
    /// 左側パスが最近使用した項目(MRU)リストに追加されるのを防ぎます。 外部アプリケーションは、ファイルまたはフォルダーの選択ダイアログのMRUリストにパスを 追加するべきではありません。
    /// </summary>
    /// <value></value>
    public bool UL { get; set; } = false;

    public string ULToArgument { get => UL ? "/ul" : ""; }

    /// <summary>
    /// /um
    /// 中央のパスが最近使用した項目(MRU)リストに追加されるのを防ぎます。 外部アプリケーションは、ファイルまたはフォルダーの選択ダイアログのMRUリストにパスを 追加するべきではありません。
    /// </summary>
    /// <value></value>
    public bool UM { get; set; } = false;

    public string UMToArgument { get => UM ? "/um" : ""; }

    /// <summary>
    /// /ur
    /// 右側パスが最近使用した項目(MRU)リストに追加されるのを防ぎます。 外部アプリケーションは、ファイルまたはフォルダーの選択ダイアログのMRUリストにパスを 追加するべきではありません。
    /// </summary>
    /// <value></value>
    public bool UR { get; set; } = false;

    public string URToArgument { get => UR ? "/ur" : ""; }

    /// <summary>
    /// /u
    /// (または/ub) 各々(左、右、中央)のパスが最近使用した項目(MRU)リストに追加されるのを防ぎます。 外部アプリケーションは、ファイルまたはフォルダーの選択ダイアログのMRUリストにパスを 追加するべきではありません。
    /// </summary>
    /// <value></value>
    public bool U { get; set; } = false;

    public string UToArgument { get => U ? "/u" : ""; }

    /// <summary>
    /// /wl
    /// 読み取り専用として左側を開きます。 比較時、左側を変更したくない場合に使用してください。
    /// </summary>
    /// <value></value>
    public bool WL { get; set; } = false;

    public string WLToArgument { get => WL ? "/wl" : ""; }

    /// <summary>
    /// /wm
    /// 読み取り専用として中央を開きます。 比較時、中央を変更したくない場合に使用してください。
    /// </summary>
    /// <value></value>
    public bool WM { get; set; } = false;

    public string WMToArgument { get => WM ? "/wm" : ""; }

    /// <summary>
    /// /wr
    /// 読み取り専用として右側を開きます。 比較時、右側を変更したくない場合に使用してください。
    /// </summary>
    /// <value></value>
    public bool WR { get; set; } = false;

    public string WRToArgument { get => WR ? "/wr" : ""; }

    /// <summary>
    /// /new
    /// 新規ブランクウインドウを開きます。
    /// </summary>
    /// <value></value>
    public bool New { get; set; } = false;

    public string NewToArgument { get => New ? "/new" : ""; }

    /// <summary>
    /// /self-compare
    /// 指定された１つのファイルとそのファイルのコピーを比較します。
    /// </summary>
    /// <value></value>
    public bool SelfCompare { get; set; } = false;

    public string SelfCompareToArgument { get => SelfCompare ? "/self-compare" : ""; }

    /// <summary>
    /// /clipboard-compare
    /// クリップボード履歴の直近２つの内容を比較します。
    /// </summary>
    /// <value></value>
    public bool ClipboardCompare { get; set; } = false;

    public string ClipboardCompareToArgument { get => ClipboardCompare ? "/clipboard-compare" : ""; }

    /// <summary>
    /// /minimize
    /// 最小化状態でWinMergeを開始します。 このオプションは長時間かかる比較を行う場合に便利です。
    /// </summary>
    /// <value></value>
    public bool Minimize { get; set; } = false;

    public string MinimizeToArgument { get => Minimize ? "/minimize" : ""; }

    /// <summary>
    /// /maximize
    /// 最大化状態でWinMergeを開始します。
    /// </summary>
    /// <value></value>
    public bool Maximize { get; set; } = false;

    public string MaximizeToArgument { get => Maximize ? "/maximize" : ""; }

    /// <summary>
    /// /fl
    /// 起動時、左側にフォーカスを当てます
    /// </summary>
    /// <value></value>
    public bool FL { get; set; } = false;

    public string FLToArgument { get => FL ? "/fl" : ""; }

    /// <summary>
    /// /fm
    /// 起動時、中央にフォーカスを当てます
    /// </summary>
    /// <value></value>
    public bool FM { get; set; } = false;

    public string FMToArgument { get => FM ? "/fm" : ""; }

    /// <summary>
    /// /fr
    /// 起動時、右側にフォーカスを当てます
    /// </summary>
    /// <value></value>
    public bool FR { get; set; } = false;

    public string FRToArgument { get => FR ? "/fr" : ""; }

    /// <summary>
    /// /l linenumber
    /// ファイルを読み込んだ後にジャンプする行番号を指定します。
    /// </summary>
    /// <value></value>
    public int? L { get; set; } = null;

    public string LToArgument { get => L == null ? "" : $"/l {L}"; }

    /// <summary>
    /// /c charpos
    /// ファイルを読み込んだ後にジャンプする文字位置を指定します。
    /// </summary>
    /// <value></value>
    public int? C { get; set; } = null;

    public string CToArgument { get => C == null ? "" : $"/c {C}"; }

    /// <summary>
    /// /table-delimiter delimiter
    /// テーブル編集用の区切り文字を指定します。タブ文字を指定する場合、「tab」または「\t」、「\x09」を指定してください。
    /// </summary>
    /// <value></value>
    public string? TableDelimiter { get; set; } = null;

    public string TableDelimiterToArgument { get => TableDelimiter == null ? "" : $"/table-delimiter \"{TableDelimiter}\""; }

    /// <summary>
    /// /dl
    /// 左側タイトルバーの説明を指定します。 デフォルトのフォルダーやファイル名テキストに上書きされます。例: /dl "Version 1.0" や /dl WorkingCopy. スペースを含む説明はダブルクォーテーションマークで括ってください。
    /// </summary>
    /// <value></value>
    public string? DL { get; set; } = null;

    public string DLToArgument { get => DL == null ? "" : $"/dl \"{DL}\""; }

    /// <summary>
    /// /dm
    /// /dlと同様に中央タイトルバーの説明を指定します。
    /// </summary>
    /// <value></value>
    public string? DM { get; set; } = null;

    public string DMToArgument { get => DM == null ? "" : $"/dm \"{DM}\""; }

    /// <summary>
    /// /dr
    /// /dlと同様に右側タイトルバーの説明を指定します。
    /// </summary>
    /// <value></value>
    public string? DR { get; set; } = null;

    public string DRToArgument { get => DR == null ? "" : $"/dr \"{DR}\""; }

    /// <summary>
    /// /al
    /// 起動時、左側で自動マージします。
    /// </summary>
    /// <value></value>
    public bool AL { get; set; } = false;

    public string ALToArgument { get => AL ? "/al" : ""; }

    /// <summary>
    /// /am
    /// 起動時、中央で自動マージします。
    /// </summary>
    /// <value></value>
    public bool AM { get; set; } = false;

    public string AMToArgument { get => AM ? "/am" : ""; }

    /// <summary>
    /// /ar
    /// 起動時、右側で自動マージします。
    /// </summary>
    /// <value></value>
    public bool AR { get; set; } = false;

    public string ARToArgument { get => AR ? "/ar" : ""; }

    // /noninteractive
    // TBD
    public bool NonInteractive { get; set; } = false;

    public string NonInteractiveToArgument { get => NonInteractive ? "/noninteractive" : ""; }

    // /noprefs
    // TBD

    /// <summary>
    /// /enableexitcode
    /// 比較結果をプロセス終了コードに設定します。0: 同一, 1: 差異あり, 2: エラー
    /// </summary>
    /// <value></value>
    public int? EnableExitCode { get; set; } = null;

    public string EnableExitCodeToArgument { get => EnableExitCode == null ? "" : $"/enableexitcode {EnableExitCode}"; }

    // /ignorews
    // TBD

    // /ignoreblanklines
    // TBD

    // /ignorecase
    // TBD

    // /ignoreeol
    // TBD

    // /ignorecodepage
    // TBD

    // /ignorecomments
    // TBD

    // /unpacker
    // TBD

    // /prediffer
    // TBD

    // /cp
    // TBD

    /// <summary>
    /// /fileext file-extension
    /// シンタックスハイライトの種類を決定するため、ファイル拡張子を指定します。
    /// </summary>
    /// <value></value>
    public string? FileExt { get; set; } = null;

    public string FileExtToArgument { get => FileExt == null ? "" : $"/fileext \"{FileExt}\""; }

    // /cfg
    // TBD

    /// <summary>
    /// leftpath
    /// 左側で開くフォルダーやファイルを指定します。
    /// </summary>
    /// <value></value>
    public string? LeftPath { get; set; } = null;

    public string LeftPathToArgument { get => LeftPath == null ? "" : $"\"{LeftPath}\""; }

    /// <summary>
    /// middlepath
    /// 中央で開くフォルダーやファイルを指定します。
    /// </summary>
    /// <value></value>
    public string? MiddlePath { get; set; } = null;

    public string MiddlePathToArgument { get => MiddlePath == null ? "" : $"\"{MiddlePath}\""; }

    /// <summary>
    /// rightpath
    /// 右側で開くフォルダーやファイルを指定します。
    /// WinMergeは、ファイルとフォルダーを比較できません。そのためパスパラメーター両方(または3つすべて) (leftpath と (middlepath と) rightpath) には、同じ種類(フォルダーかファイルのどちらか) を指し差なければなりません。 もし、WinMergeが指定したパスのどちらかを見つけることができなければ、 ファイルまたはフォルダー選択ダイアログを開きます。 ファイルまたはフォルダー選択ダイアログでは、正しいパスを選択できます。
    /// </summary>
    /// <value></value>
    public string? RightPath { get; set; } = null;

    public string RightPathToArgument { get => RightPath == null ? "" : $"\"{RightPath}\""; }

    /// <summary>
    /// /o outputpath
    /// マージした結果のファイルを保存するオプションの出力ファイルパスを指定します。
    /// 出力パスはコマンドラインからWinMergeを開始する時まれにしか必要となりません。 それはバージョンコントロールツールとともに使用されることになります。 結果ファイルとして出力パスを指定する必要があるかもしれません。 もし、出力パスを指定した場合、あるペインを変更後保存すると、変更は出力パスのファイルに保存され、 元ファイルは前の状態のままになります。
    /// バージョンコントロールシステムは一般的にtheirsや mine、mergedかまたはresolved のような用語を使用し元と結果ファイルを参照します。 もし、WinMergeコマンドラインに出力パスを指定し、バージョンコントロールシステムと連携するならば、 この順番でファイルを並べるべきです。
    /// </summary>
    /// <value></value>
    public string? O { get; set; } = null;

    public string OToArgument { get => O == null ? "" : $"/o \"{O}\""; }

    // /or
    // TBD
    public string? OR { get; set; } = null;

    public string ORToArgument { get => OR == null ? "" : $"/or \"{OR}\""; }

    /// <summary>
    /// conflictfile
    /// コンフリクトファイルを指定します。 コンフリクトファイルは通常バージョンコントロールシステムによって生成されます。 コンフリクトファイルはファイル比較ウインドウで開かれ、 「コンフリクトファイルの解決」で説明している様にマージやコンフリクトを解決することができます。 コンフリクトファイルと共に他のパスは使用できないことに注意してください。
    /// </summary>
    /// <value></value>
    // public string? ConflictFile { get; set; } = null;

    // public string ConflictFileToArgument { get => ConflictFile == null ? "" : $"\"{ConflictFile}\""; }

    /// <summary>
    /// /inifile inifile
    /// レジストリの代わりに設定の読み込みと保存に使用するINIファイルを指定します。
    /// </summary>
    /// <value></value>
    public string? IniFile { get; set; } = null;

    public string IniFileToArgument { get => IniFile == null ? "" : $"/inifile \"{IniFile}\""; }

    public override string ToString()
    {
        return String.Join(" ", ToArray());
    }

    public string ToArguments()
    {
        return ToString();
    }

    public string[] ToArray()
    {
        var arguments = new List<string>
        {
            RToArgument,
            EToArgument,
            FToArgument,
            MToArgument,
            TToArgument,
            XToArgument,
            XQToArgument,
            SToArgument,
            SWToArgument,
            S_ToArgument,
            ULToArgument,
            UMToArgument,
            URToArgument,
            UToArgument,
            WLToArgument,
            WMToArgument,
            WRToArgument,
            NewToArgument,
            SelfCompareToArgument,
            ClipboardCompareToArgument,
            MinimizeToArgument,
            MaximizeToArgument,
            FLToArgument,
            FMToArgument,
            FRToArgument,
            LToArgument,
            CToArgument,
            TableDelimiterToArgument,
            DLToArgument,
            DMToArgument,
            DRToArgument,
            ALToArgument,
            AMToArgument,
            ARToArgument,
            NonInteractiveToArgument,
            // [/noprefs] 
            EnableExitCodeToArgument,
            // [/ignorews] 
            // [/ignoreblanklines] 
            // [/ignorecase] 
            // [/ignoreeol] 
            // [/ignorecodepage] 
            // [/ignorecomments] 
            // [/unpacker unpacker-name] 
            // [/prediffer prediffer-name] 
            // [/cp codepage] 
            FileExtToArgument,
            // [/cfg name=value] 
            IniFileToArgument,
            LeftPathToArgument,
            MiddlePathToArgument,
            RightPathToArgument,
            OToArgument,
            ORToArgument,
        };

        return arguments.Where(x => x != "").ToArray();
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}