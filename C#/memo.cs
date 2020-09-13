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

参照型と値型の内部
    参照型
        常にマネージヒープ領域に割り当てられる。この時にポインタ操作が入るが、
        処理時間のボトルネックになりやすい。
        マルチプロセッサシステムでは同期が必要になって更に性能が落ちることがある。

        ガベージコレクションは不定期にメモリを解放するが、この内部操作に取り決めはなく、
        負荷の高い処理ですが、適切に調査したアプリケーションの平均的なガベージコレクションは
        同様のアンマネージ操作に比べて非常に負荷が低くなる。

        オブジェクトの中身
            オブジェクトのメンバ変数の配置の順番は保障されない。(StructLayout属性を使えば揃う)
            オブジェクトのヘッダ
            ・オブジェクトヘッダワード(同期ブロックインデックス)
            ・メソッドテーブルポインタ
            これ以降にメンバ変数が並ぶ。32bitシステムでは4byteアライメント
            64bitシステムでは8byte。したがって、メンバがbyteメンバー一つの場合でも、
            24byte使ってしまう。


        同期ブロック と lock キーワード
            同期、GCの記録、終了処理とハッシュコードストレージに用いる。

    値型
        単独で使用される場合はスタックに割り当てられる。ただし、値型を参照型に埋め込むことができ、
        その場合はヒープに割り当てられる。
        メモリレイアウトはオブジェクトに比べてシンプル。
        値型はオブジェクトヘッダワードがないため同期が取れない、ボックス化すると同期は取れるようになるが
        ボックス化はとても負荷が高い操作であるため、ボックス化を避ける方法を常に気を付けよう。

        ボックス化を避けるためにはメソッドのオーバーライドが必要になったりする。
        値型を使うのは
        ・小さなオブジェクトをたくさん作成するのでらば使用する。
        ・メモリコレクションの密度を高める必要があったとき。
        ・値型のEqualsをオーバーライドしてEqualsをオーバーロードしてIEquatable<T>を実装し、
        　演算子==と演算子!=をオーバーロードする。
        ・値型のGetHashCodeをオーバーライドする。


        Point
            2 種類のカテゴリの型を導入して、必要に応じてオブジェクト指向に代わる
            パフォーマンスの高い代替手段を提供しますが、値型を正しく実装するには
            開発者の多大な労力が必要になります。

LINQ
    シーケンス
        クエリ操作対象のデータをシーケンスという。IEnumerable<T>インターフェースを実装する
        オブジェクトはシーケンスとみなされる。

拡張メソッド
    既存の型にメソッドを追加できる。
    public static StringExtentions{
        public static string Reverse(this string str){
            ～～
        }
    }
    
    とすると、
    string name = "AAA DDD";
    name.Reverse();
    とできる。

初期化
    ・配列
        var langs = new string[] { "C#", "VB", "C ++", };
        var nums = new List < int > { 10, 20, 30, 40, };
    ※従来どおりの以下の書き方だと、入れ替えとか間に追加が手間になる。
        string[] langs = new string[3];
        langs[0] = "C#";
        langs[1] = "VB";
        langs[2] = "C ++";

    ・ディクショナリ
        var dict = new Dictionary < string, string >() {
            ["ja"] = "日本語",
            ["en"] = "英語",
            ["es"] = "スペイン語",
            ["de"] = "ドイツ 語",
        };

    ・オブジェクトの初期化
        var person = new Person {
            Name        = "新井 遥 菜",
            Birthday    = new DateTime( 1995, 11, 23),
            PhoneNumber = "012-3456-7890",
        }

    ・プロパティの初期化
        public int MinimumLength { get; set; } = 6;

        ※もし初期化を遅延させたいことがあれば以下のようにする。
        private string _name; 参照型の初期値はnullが保証されている
        public string Name {
            get {
                if (_name == null)
                    _name = GetNameFromFile();
                    return _name;
            }
    ・ファイルパスの初期化
        var path = ＠"C:\Example\Greeting.txt";

複数のコンストラクタ
    public AppVersion( int major, int minor)
     : this( major, minor, 0, 0) { 引数 4 つ の コンス トラクタ を 呼び出す }
    thisを使って梟雄かする。

条件
    変数とリテラルの大小比較
        if (age <= 10) { …… }
        変数を左に書く。

    変数の範囲比較 MIN、変数、MAXと書く
        if (MinValue <= num && num <= MaxValue)

    returnでふるいにかけていく
        if (filePath == null)
            return;
        if (GetOption() == Option. Skip)
            return;
        if (targetType != originalType)
            return;
        ～やりたい処理～

    bool値がtrueか判定する
        if (num. HasValue) {

コレクションの要素をすべて取り出す
    var items = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    foreach (var n in items) {
         Console. WriteLine( n);
    }

    List<T>のすべての要素に対して処理をする
    var nums = new List < int > { 1, 2, 3, 4, 5 };
    nums.ForEach( n => Console. Write("[{ 0}] ", n));

    ForEachメソッドは1行で書ける短い処理で使う
    優先度的にはForEach、foreach、for

null合体演算子
    var message = GetMessage(code)
    if (message == null)
        message = DefaultMessage();
    ではなく、
    var message = GetMessage(code) ?? DefaultMessage();

null合体演算子
    if (sale == null)
        return null;
    else
        return sale.Product;

    ではなく、
    return sale?. Product;

文字列を数値に変換する
    int height;
    if (int. TryParse( str, out height)) {

    なお、文字列に数値文字列が入っていることが保証されていれば、
    以下のコードを使っても問題ありません。
    int height = int. Parse( str);

参照型のキャスト
    var product = Session[" MyProduct"] as Product;
    if (product == null) {

例外を再スローする
    try {
         　︙
    } catch (FileNotFoundException ex) { 変数exには、例外オブジェクトが格納されている。
     例外オブジェクトを参照することで、例外の詳細情報を知ることができる
     
     // 例外 情報 を 使っ た 何らかの 処理
      　︙ throw; 例外 の 再 スロー }
      
    以下のように書いた場合は、例外のスタックトレース情報が消えてしまい、
    デバッグに支障をきたすこになります。
    try {
        　︙
    } catch (FileNotFoundException ex) {
        // 例外 情報 を 使っ た 何らかの 処理 　︙
        throw ex; このように書いてはいけない
    }

usingを使ったリソースの破棄
    IDisposableインターフェイスを実装しているクラス
    using (var stream = new StreamReader( filePath)) { StreamReaderは、IDisposableインターフェイスを実装している
        var texts = stream. ReadToEnd(); ︙ // ここ で、 読み取っ た データ の 処理 }

文字列
    ・大小比較なし
        if (String. Compare( str 1, str 2, ignoreCase: true) == 0)

    ・ひらがな/カタカナの区別なく比較する
        if (String. Compare( str 1, str 2, cultureInfo, CompareOptions. IgnoreKanaType) == 0)

    ・nullあるいは空文字列かを調べる
        if (String. IsNullOrEmpty( str))

    ・指定した部分文字列で始まっているか調べる
        if (str. StartsWith(" Visual")) {

    ・指定した部分文字列が含まれているか調べる
        if (str. Contains(" Program")) {

    ・すべて の 文字 が ある 条件 を 満たし て いる か 調べる
        var isAllDigits = target. All( c => Char. IsDigit( c));

    ・StringBuilder を 使っ た 文字列 の 連結
        文字列は不変オブジェクトのため、連結したりする旅に新しいオブジェクトが作られる

        var sb = new StringBuilder(); StringBuilderオブジェクトを生成
        foreach (var word in GetWords()) {
            sb. Append( word); 文字列 を 追加
        }
        var text = sb.ToString(); 文字列 に 変換 Console.
        WriteLine( text);

正規表現
    できるならstaticメソッドにしよう。staticだとキャッシュが聞くため。





※
参考
https://www.slideshare.net/neuecc/cedec-2018-c-c