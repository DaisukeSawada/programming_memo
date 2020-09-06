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

Main メソッド
    C# プログラムのエントリ ポイントは 1 つのみです。 Main メソッドを持つクラスが 2 つ以上ある場合、
    プログラムをコンパイルする際に -main コンパイラ オプションを使用して、どの Main メソッドをエン
    トリ ポイントとして使用するかを指定する必要があります。

コンストラクタ
    public Person() : this("名無し",0)
　  {
        Console.WriteLine("引数なしコンストラクタ");
    }
    //  コンストラクタ（引数あり）
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        Console.WriteLine("引数ありコンストラクタ name:{0} age:{1}", name, age);
    }

    基底クラスのコンストラクタを明示的に呼び出す
        派生クラスのコンストラクタ(引数) : base(基底クラスに渡したい引数)
        {
        }

継承
    C# のクラスは基本的に常に継承して派生クラスを作ることができるのですが、 
    場合によっては絶対に継承されたくないと言うこともあります。 このような場合、
    クラス定義時に sealed （封印された）というキーワードをつけることで、 継承を禁止することができます。

    sealed class SealedClass { }

    class Derived : SealedClass // SealedClass は継承不可なので、エラーになる。
    {
    }

    ・単一継承
    C#のクラス継承では、1つのクラスしか継承できません。これを単一継承(single inheritance)と呼びます。

抽象クラス
    抽象クラスとは、それ自身では、インスタンスを生成しないクラスのことを言う
    abstract class (クラス名){
    …
    }


インターフェース
    インターフェースは、実装がないメソッドの集合のようなものです。記述方法は以下のようになります。
    interface (インターフェース名){
        …
    }
    インターフェースには、メソッドの実装や、フィールドを持つことはできません。
    継承の場合と違い、インターフェースは複数定義することができます。

Collection

デリゲート
    デリゲートは、日本語で、「移譲する」という意味で、他のクラスのメソッドを参照する
    オブジェクトのことを指し、主にイベント処理などに用いられる重要な概念です。

    デリゲートの宣言
    delegate (戻り値の型) (名前）(引数のリスト);

    デリゲートの作成
    delegate void Action (int a);
    Action a = new Action(Func1);//Func1は　void Func1(int)と型が一致する関数
    a += new Action(Func2);//足したりできる。なお、実行順序は、追加された順になります。


例外
    try{
        (処理①)
    }catch((例外クラス) 変数){//catchはいくつでも追加可能
        (処理②)
    }finally{//finallyは一つまでしか追加できない。不要であれば定義不要
        (処理③)
    }

    例外は以下のように意図的に発生させれることも可能
    int[] nums = { 300, 600, 900 };
    if (i > nums.Length)
    {
        //  例外を発生させる
        throw new IndexOutOfRangeException();
    }