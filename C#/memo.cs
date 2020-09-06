標準出力
    ・改行あり
    Console.WriteLine("This is the first line.");

    ・開業なし
    Console.Write("This is ");

変数名のルールと表記規則
    変数名では、キャメル ケースを使用する必要があります。
    これは、最初の単語の先頭には小文字を使用し、それ以降の
    各単語の先頭には大文字を使用する記述スタイルです。 
    たとえば、「string thisIsCamelCase;」のように入力します。

逐語的文字列リテラル
    逐語的文字列リテラルでは、バックスラッシュをエスケープしなく
    てもすべての空白と文字が維持されます。
     逐語的文字列を作成するには、リテラル文字列の前に @ ディレクティブを使用します。

    Console.WriteLine(
    @"   c:\source\repos
       (this is where your code goes)");

文字列補間
    string message = greeting + " " + firstName + "!";

    string message = $"{greeting} {firstName}!";

.NET クラス ライブラリ
    特定のメソッドについて、行われる内容、そのしくみ、制限事項、例外 (エラー) が発生する状況、
    およびこれらの問題を緩和する方法を正確に理解するために、Microsoft の独自のドキュメントを
    読むのに時間を費やす可能性があります。 ドキュメントは、.NET クラス ライブラリの信頼できる
    情報源になります。 ドキュメント チームは、.NET クラス ライブラリのソフトウェア開発者と密接
    に連携して、その正確さを確保します。


配列
    string[] fraudulentOrderIDs = new string[3];
    string[] fraudulentOrderIDs = { "A123", "B456", "C789" };

    string[] names = { "Bob", "Conrad", "Grant" };
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }