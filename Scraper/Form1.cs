using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Abot.Crawler;
using Abot.Poco;
using System.Collections;

namespace Scraper
{
    public partial class Form1 : Form
    {
        public string[] orangebookWebpage;
        public string[] misumiWebpage;
        public string[] monotaroWebpage;

        public string[] orangebookCrawlPage;
        public string[] misumiCrawlPage;
        public string[] monotaroCrawlPage;

        private static string crawlType="";    //クロール対象を識別する。monotaro,orangebook,misumi を想定

        /// <summary>
        /// csvファイルをロードし、textBoxにデバック表示する。
        /// tsvファイルとして結果出力する。
        /// </summary>
        class CsvTsvConvert
        {

            public Process CSVFilePlaceProcess;
            public string inputData;
            //public string OpenFileName;
            public string ExportTSVFileName;

            /// <summary>
            /// csvファイルをOpenFileDialogによって開きます。
            /// </summary>
            public void CSVFileOpenFileDialog(string OpenFileName)
            {
                //OpenFileDialogクラスのインスタンスを作成
                OpenFileDialog ofd = new OpenFileDialog();

                //はじめのファイル名を指定する はじめに「ファイル名」で表示される文字列を指定する
                ofd.FileName = "MonotaroWebsiteList.csv";
                //はじめに表示されるフォルダを指定する 指定しない（空の文字列）の時は、現在のディレクトリが表示される
                ofd.InitialDirectory = @"\.";
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しないとすべてのファイルが表示される
                ofd.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
                //[ファイルの種類]ではじめに「すべてのファイル」が選択されているようにする
                ofd.FilterIndex = 2;
                //タイトルを設定する
                ofd.Title = "開くファイルを選択してください";
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                ofd.RestoreDirectory = true;
                //存在しないファイルの名前が指定されたとき警告を表示する デフォルトでTrueなので指定する必要はない
                ofd.CheckFileExists = true;
                //存在しないパスが指定されたとき警告を表示する デフォルトでTrueなので指定する必要はない
                ofd.CheckPathExists = true;

                //ダイアログを表示する
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき
                    //選択されたファイル名を表示する
                    Console.WriteLine(ofd.FileName);
                }
                OpenFileName = ofd.FileName;
            }

            /// <summary>
            /// tsvファイルをSaveFileDialogで保存します。
            /// </summary>
            private void TSVFileSaveFileDialog()
            {
                //SaveFileDialogクラスのインスタンスを作成
                SaveFileDialog sfd = new SaveFileDialog();

                //はじめのファイル名を指定する
                sfd.FileName = "MonotaroWebsiteList.tsv";
                //はじめに表示されるフォルダを指定する
                sfd.InitialDirectory = @".\";
                //[ファイルの種類]に表示される選択肢を指定する
                sfd.Filter =
                    "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*";
                //[ファイルの種類]ではじめに
                //「すべてのファイル」が選択されているようにする
                sfd.FilterIndex = 2;
                //タイトルを設定する
                sfd.Title = "保存先のファイルを選択してください";
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.RestoreDirectory = true;
                //既に存在するファイル名を指定したとき警告する
                //デフォルトでTrueなので指定する必要はない
                sfd.OverwritePrompt = true;
                //存在しないパスが指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                sfd.CheckPathExists = true;

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき
                    //選択されたファイル名を表示する
                    Console.WriteLine(sfd.FileName);
                }
                ExportTSVFileName = sfd.FileName;
            }


            /// <summary>
            /// csv読み込み
            /// </summary>
            public void ReadCsv(string OpenFileName)
            {
                try
                {
                    //"C:\test.txt"をShift-JISコードとして開く
                    System.IO.StreamReader sr = new System.IO.StreamReader(
                        OpenFileName,
                        System.Text.Encoding.GetEncoding("shift_jis")
                    );
                    //内容をすべて読み込む
                    inputData = sr.ReadToEnd();
                    //閉じる
                    sr.Close();
                }
                catch (System.Exception e)
                {
                    // ファイルを開くのに失敗したとき
                    System.Console.WriteLine(e.Message);
                }
            }

            /// <summary>tsvファイルに書き込む</summary>
            /// <param name="textBox">出力結果をデバック確認するtextBoxを指定</param>
            public void WriteTsv(TextBox textBox)
            {
                //Shift JISで書き込む
                //書き込むファイルが既に存在している場合は、上書きする
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    ExportTSVFileName,
                    true,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.Write(textBox.Text);
                //閉じる
                sw.Close();
            }

            /// <summary>tsvファイルに書き込む</summary>
            /// <param name="text">出力結果をデバック確認するtextを指定</param>
            public void WriteTsv(string text)
            {
                //Shift JISで書き込む
                //書き込むファイルが既に存在している場合は、上書きする
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    ExportTSVFileName,
                    true,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //TextBox1.Textの内容を書き込む
                sw.Write(text);
                //閉じる
                sw.Close();
            }

            /// <summary>
            /// splitについて、ダブルクォートをタブに変換。その1。
            /// </summary>
            private void ReplaceSplitCharacter()
            {
                inputData = inputData.Replace("\",\"", "\t");
            }

            /// <summary>
            /// ダブルクォートと改行を改行に変換
            /// </summary>
            private void ReplaceQuoteEnterCharacter()
            {
                inputData = inputData.Replace("\"\r", "\r").Replace("\"\n", "\r");
                //inputData = inputData.Replace("\"\r", "").Replace("\"\n", "");
            }

            /// <summary>
            /// 改行とダブルクォートを改行に変換
            /// </summary>
            private void ReplaceEnterQuoteCharacter()
            {
                inputData = inputData.Replace("\r\"", "").Replace("\n\"", "");
            }

            /// <summary>
            /// 入力されたcsvファイルの最初の1文字目(ダブルクォート)を削除したものを返す
            /// </summary>
            private void ReplaceHeaderQuote()
            {
                inputData = inputData.Substring(1, inputData.Length - 1);
            }

            /// <summary>
            /// 入力されたcsvファイルの最後の1文字(ダブルクォート)を削除したものを返す
            /// </summary>
            private void ReplaceHooterQuote()
            {
                inputData = inputData.Substring(0, inputData.Length - 1);
            }


            //private void cSVファイルのインポートToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    CSVFileOpenFileDialog();
            //}

            /// <summary>
            /// TSVFileExport_ToolStripMenuItemボタンをクリックすることで動作する
            /// </summary>
            private void TSVFileExport_ToolStripMenuItem_Click(object sender, EventArgs e,TextBox textBox)
            {
                TSVFileSaveFileDialog();    //セーブするtsvファイル名の選択
                WriteTsv(textBox);
            }
        }

        /// <summary>ベースクラス</summary>
        public abstract class BaseClass{
            protected string html;
            public abstract void loadScrapeHTML(string source_url, TextBox textBox);
            //abstract void displayScrapeHTML() { }
        }


        /// <summary>モノタロウを対象にスクレイプします。</summary>
        class MonotaroScraping : BaseClass
        {
            System.Random random = new System.Random();
            private int randomForSleepTime;


            /// <summary>スクレイプ対象ページを設定します。</summary>
            /// <param name="source_url">スクレイプ対象URL</param>
            /// <param name="textBox">出力結果をデバック確認するtextBoxを指定</param>
            public override void loadScrapeHTML(string source_url, TextBox textBox)
            {
                randomForSleepTime = random.Next(21, 1857);
                System.Threading.Thread.Sleep(randomForSleepTime);  //接続直前にランダムでスリープさせる。

                try
                {
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead(source_url);
                    Encoding enc = Encoding.GetEncoding("shift_jis");
                    StreamReader sr = new StreamReader(st, enc);
                    html = sr.ReadToEnd();
                    sr.Close();
                    st.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "[接続失敗]");
                }

                //UTF-8ならこれ1行でもOK
                //string _html = wc.DownloadString(source_url);

                DateTime dateTimeNow = DateTime.Now;

                //HTMLを解析する
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);


                //１．XPathで取得するNodeを指定 商品グループ名 _nodesProdNames
                HtmlAgilityPack.HtmlNodeCollection _nodesProdNames = doc.DocumentNode.SelectNodes(
                    //"/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/article[1]/div[1]/div[2]/div[1]/h1[1]"
                    //"//div[1]/h1[1]"
                    "//div[1]/h1[@class=\"pd_product_name\"]"
                );
                var nodesProdNames = _nodesProdNames;
                //表示
                string prodName = "";
                foreach (var nodesProdName in nodesProdNames)
                {
                    prodName = nodesProdName.InnerText.ToString();
                }


                //２．XPathで取得するNodeを指定 メーカー名   _nodesMakerNames
                HtmlAgilityPack.HtmlNodeCollection _nodesMakerNames = doc.DocumentNode.SelectNodes(
                    //"//div[1]/h1[1]"
                    "//div[@class=\"pd_brand_name itd_brand\"]"
                );
                var nodesMakerNames = _nodesMakerNames;
                //表示
                string makerName = "";
                foreach (var nodesMakerName in nodesMakerNames)
                {
                    makerName = nodesMakerName.InnerText.ToString();
                }





                //３．XPathで取得するNodeを指定 商品通常価格取得    _nodesProdPrice
                HtmlAgilityPack.HtmlNodeCollection _nodesProdPrice = doc.DocumentNode.SelectNodes(
                    //"//tr[@class=\"pd_list data-ee-sku\"]//table[@class=\"pd_price\"]"  // 商品価格一覧全体を出力
                    //"//td[contains(@class,\"pd_price pd_price_color pd_price_sales_price\") or contains(@class,\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\")]"         //通常商品、ボリュームディスカウント価格が行をまたぎ誤出力。
                    "//td[@class=\"pd_price pd_price_color pd_price_sales_price\"]"         //通常商品またはボリュームディスカウント適用前の販売価格を出力
                    //"//td[@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\"]"         //ボリュームディスカウント適用後の販売価格を出力
                    //"//td[@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\" or not(@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\")]"   //ボリュームディスカウント適用後の販売価格を出力。nullの場合も出力
                );


                //これ別にいらないが・・・
                var nodesProdPrice = _nodesProdPrice;

                List<string> nodeProdPriceStandardValue = new List<string>();

                try
                {
                    foreach (var nodeProdPrice in nodesProdPrice)
                    {
                        nodeProdPriceStandardValue.Add(nodeProdPrice.InnerText.Replace("\n", "@").Replace("@@@@@@@@@@@@-@@@", "\t").Replace("@@@@@", "\t").Replace("@@@", "\t").Replace("@@", "\t").Replace("@", "\t").Replace("￥", "").Replace(",", ""));
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "[スクレイプ失敗]");
                }





                //４．XPathで取得するNodeを指定 商品明細一覧取得    _nodesProdDetail
                HtmlAgilityPack.HtmlNodeCollection _nodesProdDetail = doc.DocumentNode.SelectNodes(
                    //"/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/article[1]/div[1]/div[2]/div[6]/table[1]/tbody[1]/tr"
                    //"//div[6]/table[1]/tbody[1]/tr" //https://www.monotaro.com/g/00368202/ でok.確認済み
                    //"//tr/td[@class=\"pd_list\"]"   //注文コード、品番、材質、呼び径、外径(マルmm)、内径(マルmm)のカラムが取得可能
                    //"//tr/td[1][@class=\"pd_list\"]"   //注文コードのみ
                    "//tr[@class=\"pd_list data-ee-sku\"]"  //商品明細すべてが出力される
                );


                //これ別にいらないが・・・
                var nodesProdDetail = _nodesProdDetail;
                //var nodesProdDetail = _nodesProdDetail.Skip(1);   //商品詳細一覧のヘッダ1行目を削除


                string value = "";
                int count = 0;
                foreach (var nodeProdDetail in nodesProdDetail)
                {
                    //value = nodeProdDetail.InnerText.Replace("\n\n", "").Replace("\n", "\t").Replace(" ￥", "\t￥") ;   //商品詳細不要情報を削除・整形し一旦valueに代入
                    //value = nodeProdDetail.InnerText.Replace("\r", "@").Replace("\n", "@").Replace("@","\t");   //商品詳細不要情報を削除・整形し一旦valueに代入
                    value = nodeProdDetail.InnerText.Replace("\n", "@").Replace("@@@@@@@@@@@@-@@@", "\t").Replace("@@@@@", "\t").Replace("@@@", "\t").Replace("@@", "\t").Replace("@", "\t");   //商品詳細不要情報を削除・整形し一旦valueに代入

                    textBox.Text += dateTimeNow.ToString() + "\t";                  //スクレイピングした時刻を出力
                    textBox.Text += prodName.ToString()+"\t";                       //商品グループ名出力
                    textBox.Text += makerName.Replace("\n", "").ToString() + "\t";  //メーカー名出力
                    textBox.Text += source_url;                         //行に参照したhttpアドレスを出力
                    textBox.Text += nodeProdPriceStandardValue[count];  //商品価格
                    textBox.Text += value.ToString();                   //商品詳細出力
                    textBox.Text += "\r\n";                             //商品ごとに改行
                    count++;
                }
                //textBox.Text += "\t"+ randomForSleepTime;   //スリープ時間をデバック出力
            }

            /// <summary>
            /// スクレイプ結果を出力を設定します。
            /// <param name="scrapeTag">取得したいHTMLタグを代入</param>
            /// </summary>
            //public void displayScrapeHTML(TextBox textBox)
            //{
                
            //    ////HTMLを解析する
            //    //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //    //doc.LoadHtml(html);


            //    ////XPathで取得するNodeを指定 商品グループ名
            //    //HtmlAgilityPack.HtmlNodeCollection _nodesProdNames = doc.DocumentNode.SelectNodes(
            //    //    "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/article[1]/div[1]/div[2]/div[1]/h1[1]"
            //    //);
            //    //var nodesProdNames = _nodesProdNames;
            //    ////表示
            //    //string prodName = "";
            //    //foreach (var nodesProdName in nodesProdNames)
            //    //{
            //    //    prodName = nodesProdName.InnerText.ToString();
            //    //}


            //    ////XPathで取得するNodeを指定 商品明細一覧取得
            //    //HtmlAgilityPack.HtmlNodeCollection _nodes = doc.DocumentNode.SelectNodes(
            //    //    "/html[1]/body[1]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/article[1]/div[1]/div[2]/div[6]/table[1]/tbody[1]/tr"
            //    //);
            //    ////これ別にいらないが・・・
            //    //var nodes = _nodes;
            //    ////表示
            //    //string value = "";
            //    //foreach (var node in nodes)
            //    //{
            //    //    value = node.InnerText.Replace("\n\n", "").Replace("\n", "\t").Replace(" ￥", "\t￥") + "\r\n";
            //    //    textBox.Text += prodName.ToString()+"\t";
            //    //    textBox.Text += value.ToString();
            //    //}

            //}
        }


        /// <summary>オレンジブックを対象にスクレイプします。</summary>
        class OrangeBookScraping : BaseClass
        {
            System.Random random = new System.Random();
            private int randomForSleepTime;

            /// <summary>スクレイプ対象ページを設定します。</summary>
            /// <param name="source_url">スクレイプ対象URL</param>
            /// <param name="textBox">出力結果をデバック確認するtextBoxを指定</param>
            public override void loadScrapeHTML(string source_url, TextBox textBox)
            {
                randomForSleepTime = random.Next(21, 1857);
                System.Threading.Thread.Sleep(randomForSleepTime);  //接続直前にランダムでスリープさせる。

                try
                {
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead(source_url);
                    Encoding enc = Encoding.GetEncoding("utf-8");
                    StreamReader sr = new StreamReader(st, enc);
                    html = sr.ReadToEnd();
                    sr.Close();
                    st.Close();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "[接続失敗]");
                }

                //UTF-8ならこれ1行でもOK
                //string _html = wc.DownloadString(source_url);

                DateTime dateTimeNow = DateTime.Now;

                //HTMLを解析する
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);


                //XPathで取得するNodeを指定 商品グループ名 _nodesProdNames
                HtmlAgilityPack.HtmlNodeCollection _nodesProdNames = doc.DocumentNode.SelectNodes(
                    //"//div[@class=\"item-title\"]/h2/text()"
                    //"//div[@class=\"item-title\"]/descendant::h2/text()"
                    //"//div[@id=\"result-group-item\"]/div[@class=\"group-box\"]/div[@class=\"grouping\"]/div[@class=\"item-title\"]/h2//text()"
                    //"/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[4]/div[1]/div[1]/h2[1]"
                    //"//div[@id=\"result-group-item\"]/div[@class=\"group-box\"]/div[@class=\"grouping\"]/div[@class=\"item-title\"]/h2/text()"
                    "//div[@class=\"single\"]/div[@class=\"heightLineParent\"]/div[@class=\"single-main\"]/div[@class=\"single-title\"]/h2[1]/a/@href"

                );
                var nodesProdNames = _nodesProdNames;
                //limit:100のオレンジブックページを対象としたので、配列を100とする
                string[]prodName= new string[100];
                int prodNameCounter=0;
                foreach (var nodesProdName in nodesProdNames)
                {
                    prodName[prodNameCounter] = nodesProdName.InnerText.ToString();
                    prodNameCounter++;
                }



                //XPathで取得するNodeを指定 メーカー名   _nodesMakerNames
                HtmlAgilityPack.HtmlNodeCollection _nodesMakerNames = doc.DocumentNode.SelectNodes(
                    //"//div[@class=\"item-detail\"]/p"
                    //"//div[@class=\"group-box\"]/div[@class=\"grouping\"]/div[@class=\"item-title\"]/h2[1]"
                    //"//div[@class=\"single\"]/div[@class=\"heightLineParent\"]/div[@class=\"single-main\"]/div[@class=\"single-title\"]/h2[1]/a/@href"//(仮)
                    "//div[@class=\"single\"]/div[@class=\"heightLineParent\"]/div[@class=\"single-main\"]/div[@class=\"single-cont\"]/p/strong"//(仮)

                );
                var nodesMakerNames = _nodesMakerNames;
                //limit:100のオレンジブックページを対象としたので、配列を100とする
                string[] makerName = new string[100];
                int makerNameCounter = 0;
                foreach (var nodesMakerName in nodesMakerNames)
                {
                    makerName[makerNameCounter] = nodesMakerName.InnerText.ToString();
                    makerNameCounter++;
                }



                //XPathで取得するNodeを指定 商品明細一覧取得    _nodesProdDetail
                HtmlAgilityPack.HtmlNodeCollection _nodesProdDetail = doc.DocumentNode.SelectNodes(
                    //"/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[5]/div[1]/div[4]/div[1]/div[2]/div[3]/div[1]/table[1]/tr[2]"
                    //"/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[4]"
                    //"/html[1]/body[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[4]/div[1]/div[4]/div[1]"
                    //"//div[@id=\"result-group-item\"]/div[@class=\"group-box\"]/div[@class=\"grouping\"]/div[@class=\"item-title\"]/h2/text()"
                    //"//div[@class=\"sFDataInner\"]/tbody/tr/td"
                    //"//div[@class=\"group-box\"]/div[@class=\"grouping\"]/div[@class=\"cont-box-varia\"]/div/div/div[@class=\"cont-form-table\"]/div[@class=\"fakeContainer\"]/div[@class=\"sBase\"]/div[@class=\"sFData\"]//tbody/tr/td"
                    "//div[@class=\"single-info\"]//td"

                );
                //これ別にいらないが・・・
                var nodesProdDetail = _nodesProdDetail;
                //var nodesProdDetail = _nodesProdDetail.Skip(1);   //商品詳細一覧のヘッダ1行目を削除


                string value = "";
                prodNameCounter = 0;
                makerNameCounter = 0;

                foreach (var nodeProdDetail in nodesProdDetail)
                {
                    value = nodeProdDetail.InnerText + "\t";   //商品詳細不要情報を削除・整形し一旦valueに代入

                    //SKU単位の商品情報がtr[1]～tr[5]で表現されているので、tr[1]のときに商品グループ単位の要素を出力。
                    if (nodeProdDetail.LastChild.XPath.Contains("tr[1]"))
                    {
                        textBox.Text += dateTimeNow.ToString() + "\t";      //スクレイピングした時刻を出力
                        textBox.Text += prodName[prodNameCounter] + "\t";   //商品グループ名出力
                        textBox.Text += makerName[makerNameCounter].Replace("&nbsp;"," ").Replace("&nbsp"," ") + "\t"; //メーカー名出力
                        textBox.Text += source_url + "\t";             //行に参照したhttpアドレスを出力

                    };

                    textBox.Text += value.ToString();           //商品詳細出力

                    //SKU単位の商品情報がtr[1]～tr[5]で表現されているので、tr[5]ごとに改行する。
                    if (nodeProdDetail.LastChild.XPath.Contains("tr[5]"))
                    {
                        textBox.Text += "\n";
                        prodNameCounter++;
                        makerNameCounter++;
                    };


                }
                //textBox.Text += "\t"+ randomForSleepTime;   //スリープ時間をデバック出力
            }
        }


        /// <summary>ミスミを対象にスクレイプします。</summary>
        class MisumiScraping : BaseClass
        {
            System.Random random = new System.Random();
            private int randomForSleepTime;


            /// <summary>スクレイプ対象ページを設定します。</summary>
            /// <param name="source_url">スクレイプ対象URL</param>
            /// <param name="textBox">出力結果をデバック確認するtextBoxを指定</param>
            public override void loadScrapeHTML(string source_url, TextBox textBox)
            {
                randomForSleepTime = random.Next(21, 1857);
                System.Threading.Thread.Sleep(randomForSleepTime);  //接続直前にランダムでスリープさせる。

                try
                {
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead(source_url);
                    Encoding enc = Encoding.GetEncoding("shift_jis");
                    StreamReader sr = new StreamReader(st, enc);
                    html = sr.ReadToEnd();
                    sr.Close();
                    st.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "[接続失敗]");
                }

                //UTF-8ならこれ1行でもOK
                //string _html = wc.DownloadString(source_url);

                DateTime dateTimeNow = DateTime.Now;

                //HTMLを解析する
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);


                //１．XPathで取得するNodeを指定 商品グループ名 _nodesProdNames
                HtmlAgilityPack.HtmlNodeCollection _nodesProdNames = doc.DocumentNode.SelectNodes(
                    "//h1[@itemprop=\"name\"]"
                );
                var nodesProdNames = _nodesProdNames;
                //表示
                string prodName = "";
                foreach (var nodesProdName in nodesProdNames)
                {
                    prodName = nodesProdName.InnerText.ToString();
                }





                //２．XPathで取得するNodeを指定 メーカー名   _nodesMakerNames
                HtmlAgilityPack.HtmlNodeCollection _nodesMakerNames = doc.DocumentNode.SelectNodes(
                    //"//div[1]/h1[1]"
                    "//div[@class=\"brand\"]/span[@class=\"brand__categoryLink\"]/a[@itemprop=\"brand\"]/span[@itemprop=\"name\"]"

                );
                var nodesMakerNames = _nodesMakerNames;
                //表示
                string makerName = "";
                foreach (var nodesMakerName in nodesMakerNames)
                {
                    makerName = nodesMakerName.InnerText.ToString();
                }





                //３．XPathで取得するNodeを指定 商品通常価格取得    _nodesProdPrice
                HtmlAgilityPack.HtmlNodeCollection _nodesProdPrice = doc.DocumentNode.SelectNodes(
                    //"//tr[@class=\"pd_list data-ee-sku\"]//table[@class=\"pd_price\"]"  // 商品価格一覧全体を出力
                    //"//td[contains(@class,\"pd_price pd_price_color pd_price_sales_price\") or contains(@class,\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\")]"         //通常商品、ボリュームディスカウント価格が行をまたぎ誤出力。
                    //"//td[@class=\"pd_price pd_price_color pd_price_sales_price\"]"         //通常商品またはボリュームディスカウント適用前の販売価格を出力
                    //"//td[@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\"]"         //ボリュームディスカウント適用後の販売価格を出力
                    //"//td[@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\" or not(@class=\"pd_price pd_price_color pd_price_border_bottom pd_price_sales_price\")]"   //ボリュームディスカウント適用後の販売価格を出力。nullの場合も出力
                    //"//tr[]/td[]/span[@class=\"price usualPrice\"]"
                    "//div[@id=\"listContents\"]"
                );

                //これ別にいらないが・・・
                var nodesProdPrice = _nodesProdPrice;

                List<string> nodeProdPriceStandardValue = new List<string>();

                try
                {
                    foreach (var nodeProdPrice in nodesProdPrice)
                    {
                        nodeProdPriceStandardValue.Add(nodeProdPrice.InnerText.Replace("\n", "@").Replace("@@@@@@@@@@@@-@@@", "\t").Replace("@@@@@", "\t").Replace("@@@", "\t").Replace("@@", "\t").Replace("@", "\t").Replace("￥", "").Replace(",", ""));
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, "[スクレイプ失敗]");
                }






                //４．XPathで取得するNodeを指定 商品明細一覧取得    _nodesProdDetail
                HtmlAgilityPack.HtmlNodeCollection _nodesProdDetail = doc.DocumentNode.SelectNodes(
                    //"//tr[@class=\"pd_list data-ee-sku\"]"  //商品明細すべてが出力される
//                    "//tr[]/td[@class=\"model\"]/div[@class=\"title\"]/a[@href]"
                    "//div[@id=\"listContents\"]/table[@id=\"ListTable\"]/tbody/tr[3]/td"

                );

                //これ別にいらないが・・・
                var nodesProdDetail = _nodesProdDetail;
                //var nodesProdDetail = _nodesProdDetail.Skip(1);   //商品詳細一覧のヘッダ1行目を削除





                string value = "";
                int count = 0;
                foreach (var nodeProdDetail in nodesProdDetail)
                {
                    //value = nodeProdDetail.InnerText.Replace("\n", "@").Replace("@@@@@@@@@@@@-@@@", "\t").Replace("@@@@@", "\t").Replace("@@@", "\t").Replace("@@", "\t").Replace("@", "\t");   //商品詳細不要情報を削除・整形し一旦valueに代入
                    value = nodeProdDetail.InnerText;

                    textBox.Text += dateTimeNow.ToString() + "\t";                      //スクレイピングした時刻を出力
                    textBox.Text += prodName.ToString() + "\t";                         //商品グループ名出力
                    //textBox.Text += makerName.Replace("\n", "").ToString() + "\t";    //メーカー名出力
                    //textBox.Text += source_url;                         //行に参照したhttpアドレスを出力
                    //textBox.Text += nodeProdPriceStandardValue[count];  //商品価格
                    //textBox.Text += value.ToString();                   //商品詳細出力
                    //textBox.Text += "\r\n";                             //商品ごとに改行
                    count++;
                }
                //textBox.Text += "\t"+ randomForSleepTime;   //スリープ時間をデバック出力
            }

        }


        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>本番出力。オレンジブックの価格データ取得</summary>
        private void OrangebookScrape_Click(object sender, EventArgs e)
        {
            OrangeBookScraping orangebookScraping = new OrangeBookScraping();
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.ExportTSVFileName = @"..\..\..\ExportOrangebookWebsitePrice.tsv";
            csvTsvConver.ReadCsv(@"..\..\..\OrangebookWebsiteList.csv");

            string[] delimiter = { "\r\n" };
            orangebookWebpage = csvTsvConver.inputData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

            //対象サイトをtextBox1に出力
            for (int i = 0; i < orangebookWebpage.Length; i++)
            {
                //textBox1.Text += monotaroWebpage[i];
                //textBox1.Text += "\r\n";
                orangebookScraping.loadScrapeHTML(orangebookWebpage[i], textBox1);    //商品グループ単位でスクレイプ結果を出力
            }

            csvTsvConver.WriteTsv(textBox1);

        }

        /// <summary>本番出力。モノタロウの価格データ取得</summary>
        private void MonotaroScrape_Click(object sender, EventArgs e)
        {
            MonotaroScraping monotaroScraping = new MonotaroScraping();
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.ExportTSVFileName = @"..\..\..\ExportMonotaroWebsitePrice.tsv";
            csvTsvConver.ReadCsv(@"..\..\..\MonotaroWebsiteList.csv");

            string[] delimiter = {"\r\n"};
            monotaroWebpage =csvTsvConver.inputData.Split(delimiter,StringSplitOptions.RemoveEmptyEntries);


            //対象サイトをtextBox1に出力
            for (int i = 0; i < monotaroWebpage.Length; i++)
            {
                //textBox1.Text += monotaroWebpage[i];
                //textBox1.Text += "\r\n";
                monotaroScraping.loadScrapeHTML(monotaroWebpage[i], textBox1);    //商品グループ単位でスクレイプ結果を出力
            }

            csvTsvConver.WriteTsv(textBox1);

        }

        /// <summary>本番出力。ミスミの価格データ取得</summary>
        private void MisumiScrape_Click(object sender, EventArgs e)
        {
            MisumiScraping MisumiScraping = new MisumiScraping();
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.ExportTSVFileName = @"..\..\..\ExportMisumiWebsitePrice.tsv";
            csvTsvConver.ReadCsv(@"..\..\..\MisumiWebsiteList.csv");

            string[] delimiter = { "\r\n" };
            misumiWebpage = csvTsvConver.inputData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);


            //対象サイトをtextBox1に出力
            for (int i = 0; i < misumiWebpage.Length; i++)
            {
                //textBox1.Text += MisumiWebpage[i];
                //textBox1.Text += "\r\n";
                MisumiScraping.loadScrapeHTML(misumiWebpage[i], textBox1);    //商品グループ単位でスクレイプ結果を出力
            }

            csvTsvConver.WriteTsv(textBox1);

        }


        /// <summary>デバッグ出力。モノタロウの価格データ取得</summary>
        private void button2_Click(object sender, EventArgs e)
        {
            //HTMLを読み込む
            string source_url =
                "https://www.monotaro.com/p/0867/5143/";

            WebClient wc = new WebClient();
            Stream st = wc.OpenRead(source_url);
            Encoding enc = Encoding.GetEncoding("shift_jis");
            StreamReader sr = new StreamReader(st, enc);
            string html = sr.ReadToEnd();
            sr.Close();
            st.Close();

            //UTF-8ならこれ1行でもOK
            //string _html = wc.DownloadString(source_url);

            //HTMLを解析する
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(html);

            //XPathで取得するNodeを指定
            HtmlAgilityPack.HtmlNodeCollection _nodes = doc.DocumentNode.SelectNodes(
                "/ html[1] / body[1] / div[1] / div[2] / div[1] / div[1] / div[1] / div[1] / div[2] / div[4] / dl[1]"
            );

            //これ別にいらないが・・・
            var nodes = _nodes;

            //表示
            string value = "";
            foreach (var node in nodes)
            {
                //value = node.InnerText + "\r\n";
                value = node.InnerText + "@";
                textBox1.Text += value.ToString();
            }
        }

        //private void MonotaroCrawlButton_Click(object sender, EventArgs e)
        //{

        //}

        /// <summary>モノタロウをクロールする</summary>
        private void MonotaroCrawlButton_Click(object sender, EventArgs e)
        {
            crawlType = "monotaro"; //モノタロウのクロールとして識別
            log4net.Config.XmlConfigurator.Configure();

            CsvTsvConvert crawlSiteTextConvert = new CsvTsvConvert();
            crawlSiteTextConvert.ReadCsv(@"..\..\..\MonotaroCrawlList.csv");    //モノタロウクロールファイルのロード

            string[] delimiter = { "\r\n" };
            monotaroCrawlPage = crawlSiteTextConvert.inputData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);     //モノタロウクロールデータのロード

            for (int i = 0; i < monotaroCrawlPage.Length; i++)
            {
                Uri uriToCrawl = new Uri(monotaroCrawlPage[i].ToString()); //モノタロウクロールサイトを指定
                //Uri uriToCrawl = new Uri("https://www.monotaro.com/g/00368202/"); //モノタロウクロールサイト静的を指定でテスト済み
                IWebCrawler crawler;

                //Uncomment only one of the following to see that instance in action
                crawler = GetDefaultWebCrawler();
                //crawler = GetManuallyConfiguredWebCrawler();
                //crawler = GetCustomBehaviorUsingLambdaWebCrawler();

                //Subscribe to any of these asynchronous events, there are also sychronous versions of each.
                //This is where you process data about specific events of the crawl
                crawler.PageCrawlStartingAsync += crawler_ProcessPageCrawlStarting;
                crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompleted;
                crawler.PageCrawlDisallowedAsync += crawler_PageCrawlDisallowed;
                crawler.PageLinksCrawlDisallowedAsync += crawler_PageLinksCrawlDisallowed;

                //Start the crawl
                //This is a synchronous call
                CrawlResult result = crawler.Crawl(uriToCrawl);

                //Now go view the log.txt file that is in the same directory as this executable. It has
                //all the statements that you were trying to read in the console window :).
                //Not enough data being logged? Change the app.config file's log4net log level from "INFO" TO "DEBUG"

            }

        }

        /// <summary>オレンジブックをクロールする</summary>
        private void OrangebookCrawlButton_Click(object sender, EventArgs e)
        {
            crawlType = "orangebook"; //オレンジブックのクロールとして識別
            log4net.Config.XmlConfigurator.Configure();

            CsvTsvConvert crawlSiteTextConvert = new CsvTsvConvert();
            crawlSiteTextConvert.ReadCsv(@"..\..\..\OrangebookCrawlList.csv");    //オレンジブッククロールファイルのロード

            string[] delimiter = { "\r\n" };
            orangebookCrawlPage = crawlSiteTextConvert.inputData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);     //オレンジブッククロールデータのロード

            for (int i = 0; i < orangebookCrawlPage.Length; i++)
            {
                Uri uriToCrawl = new Uri(orangebookCrawlPage[i].ToString()); //オレンジブッククロールサイトを指定
                IWebCrawler crawler;

                //Uncomment only one of the following to see that instance in action
                crawler = GetDefaultWebCrawler();
                //crawler = GetManuallyConfiguredWebCrawler();
                //crawler = GetCustomBehaviorUsingLambdaWebCrawler();

                //Subscribe to any of these asynchronous events, there are also sychronous versions of each.
                //This is where you process data about specific events of the crawl
                crawler.PageCrawlStartingAsync += crawler_ProcessPageCrawlStarting;
                crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompleted;
                crawler.PageCrawlDisallowedAsync += crawler_PageCrawlDisallowed;
                crawler.PageLinksCrawlDisallowedAsync += crawler_PageLinksCrawlDisallowed;

                //Start the crawl
                //This is a synchronous call
                CrawlResult result = crawler.Crawl(uriToCrawl);

                //Now go view the log.txt file that is in the same directory as this executable. It has
                //all the statements that you were trying to read in the console window :).
                //Not enough data being logged? Change the app.config file's log4net log level from "INFO" TO "DEBUG"

            }
        }

        /// <summary>ミスミをクロールする</summary>
        private void MisumiCrawlButton_Click(object sender, EventArgs e)
        {
            crawlType = "misumi"; //ミスミのクロールとして識別
            log4net.Config.XmlConfigurator.Configure();

            CsvTsvConvert crawlSiteTextConvert = new CsvTsvConvert();
            crawlSiteTextConvert.ReadCsv(@"..\..\..\MisumiCrawlList.csv");    //ミスミクロールファイルのロード

            string[] delimiter = { "\r\n" };
            misumiCrawlPage = crawlSiteTextConvert.inputData.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);     //オレンジブッククロールデータのロード

            for (int i = 0; i < misumiCrawlPage.Length; i++)
            {
                Uri uriToCrawl = new Uri(misumiCrawlPage[i].ToString()); //ミスミクロールサイトを指定
                IWebCrawler crawler;

                //Uncomment only one of the following to see that instance in action
                crawler = GetDefaultWebCrawler();
                //crawler = GetManuallyConfiguredWebCrawler();
                //crawler = GetCustomBehaviorUsingLambdaWebCrawler();

                //Subscribe to any of these asynchronous events, there are also sychronous versions of each.
                //This is where you process data about specific events of the crawl
                crawler.PageCrawlStartingAsync += crawler_ProcessPageCrawlStarting;
                crawler.PageCrawlCompletedAsync += crawler_ProcessPageCrawlCompleted;
                crawler.PageCrawlDisallowedAsync += crawler_PageCrawlDisallowed;
                crawler.PageLinksCrawlDisallowedAsync += crawler_PageLinksCrawlDisallowed;

                //Start the crawl
                //This is a synchronous call
                CrawlResult result = crawler.Crawl(uriToCrawl);

                //Now go view the log.txt file that is in the same directory as this executable. It has
                //all the statements that you were trying to read in the console window :).
                //Not enough data being logged? Change the app.config file's log4net log level from "INFO" TO "DEBUG"

            }
        }

        private static IWebCrawler GetDefaultWebCrawler()
        {
            return new PoliteWebCrawler();
        }

        private static IWebCrawler GetManuallyConfiguredWebCrawler()
        {
            //Create a config object manually
            CrawlConfiguration config = new CrawlConfiguration();
            config.CrawlTimeoutSeconds = 0;
            config.DownloadableContentTypes = "text/html, text/plain";
            config.IsExternalPageCrawlingEnabled = false;
            config.IsExternalPageLinksCrawlingEnabled = false;
            config.IsRespectRobotsDotTextEnabled = false;
            config.IsUriRecrawlingEnabled = false;
            config.MaxConcurrentThreads = 10;
            config.MaxPagesToCrawl = 5;
            config.MaxLinksPerPage = 100;
            config.MaxPagesToCrawlPerDomain = 0;
            config.MinCrawlDelayPerDomainMilliSeconds = 1000;
            config.MaxCrawlDepth = 20;

            //Add you own values without modifying Abot's source code.
            //These are accessible in CrawlContext.CrawlConfuration.ConfigurationException object throughout the crawl
            config.ConfigurationExtensions.Add("Somekey1", "SomeValue1");
            config.ConfigurationExtensions.Add("Somekey2", "SomeValue2");

            //Initialize the crawler with custom configuration created above.
            //This override the app.config file values
            return new PoliteWebCrawler(config, null, null, null, null, null, null, null, null);
        }

        /// <summary>クローラー開始時のイベント</summary>
        static void crawler_ProcessPageCrawlStarting(object sender, PageCrawlStartingArgs e)
        {
            //Process data
        }

        /// <summary>クローラー完了時のイベント</summary>
        static void crawler_ProcessPageCrawlCompleted(object sender, PageCrawlCompletedArgs e)
        {
            //string crawledText = "";
            string crawledUri = "";

            CrawledPage crawledPage = e.CrawledPage;

            //crawledText += crawledPage.Content.Text;    //取得したHTMLソース。不要

            if (crawlType == "monotaro")
            {

                //モノタロウから取得したUriから、/g/を含む行のみを変数に代入する。
                if (crawledPage.Uri.AbsoluteUri.Contains("/g/"))
                {
                    crawledUri += crawledPage.Uri.AbsoluteUri + "\r\n";
                }

                CsvTsvConvert crawledTextConvert = new CsvTsvConvert();

                //crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportCrawledText.txt";
                //crawledTextConvert.WriteTsv(crawledText);
                crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportMonotaroCrawledUri.txt";
                crawledTextConvert.WriteTsv(crawledUri);
            }
            else if(crawlType == "orangebook")
            {

                crawledUri += crawledPage.Uri.AbsoluteUri + "\r\n";

                CsvTsvConvert crawledTextConvert = new CsvTsvConvert();

                //crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportCrawledText.txt";
                //crawledTextConvert.WriteTsv(crawledText);
                crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportOrangebookCrawledUri.txt";
                crawledTextConvert.WriteTsv(crawledUri);
            }
            else if (crawlType == "misumi")
            {

                crawledUri += crawledPage.Uri.AbsoluteUri + "\r\n";

                CsvTsvConvert crawledTextConvert = new CsvTsvConvert();

                //crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportCrawledText.txt";
                //crawledTextConvert.WriteTsv(crawledText);
                crawledTextConvert.ExportTSVFileName = @"..\..\..\ExportMisumiCrawledUri.txt";
                crawledTextConvert.WriteTsv(crawledUri);
            }

        }

        /// <summary>ページリンククロール禁止時のイベント</summary>
        static void crawler_PageLinksCrawlDisallowed(object sender, PageLinksCrawlDisallowedArgs e)
        {
            //Process data
        }

        /// <summary>ページクロール禁止時のイベント</summary>
        static void crawler_PageCrawlDisallowed(object sender, PageCrawlDisallowedArgs e)
        {
            //Process data
        }




        /// <summary>モノタロウのクロール対象Webページ一覧の設定ファイルを開く</summary>
        private void monotaroCrawlSetting_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\MonotaroCrawlList.csv");
        }

        /// <summary>オレンジブックのクロール対象Webページ一覧の設定ファイルを開く</summary>
        private void orangeBookCrawlSetting_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\OrangebookCrawlList.csv");
        }

        /// <summary>ミスミのクロール対象Webページ一覧の設定ファイルを開く</summary>
        private void misumiCrawlSetting_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\MisumiCrawlList.csv");
        }




        /// <summary>モノタロウのスクレイプ対象Webページ一覧の設定ファイルを開く</summary>
        private void monotaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\MonotaroWebsiteList.csv");
        }

        /// <summary>オレンジブックのスクレイプ対象Webページ一覧の設定ファイルを開く</summary>
        private void orangeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\OrangebookWebsiteList.csv");
        }

        /// <summary>ミスミのスクレイプ対象Webページ一覧の設定ファイルを開く</summary>
        private void misumiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\MisumiWebsiteList.csv");
        }




        /// <summary>モノタロウのクロールしたURLリストファイルを開く</summary>
        private void monotaroCrawlResult_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConverForMonotaro = new CsvTsvConvert();
            csvTsvConverForMonotaro.CSVFilePlaceProcess = Process.Start(@"..\..\..\ExportMonotaroCrawledUri.txt");
        }

        /// <summary>オレンジブックのクロールしたURLリストファイルを開く</summary>
        private void orangeBookCrawlResult_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConverForOrangebook = new CsvTsvConvert();
            csvTsvConverForOrangebook.CSVFilePlaceProcess = Process.Start(@"..\..\..\ExportOrangebookCrawledUri.txt");
        }

        /// <summary>ミスミのクロールしたURLリストファイルを開く</summary>
        private void misumiCrawlResult_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConverForMisumi = new CsvTsvConvert();
            csvTsvConverForMisumi.CSVFilePlaceProcess = Process.Start(@"..\..\..\ExportMisumiCrawledUri.txt");
        }




        /// <summary>クロールさせるWEBページ範囲の設定ファイルを開く。全サイト共通。</summary>
        private void CrawlRangeSetting_Click(object sender, EventArgs e)
        {
            CsvTsvConvert csvTsvConver = new CsvTsvConvert();
            csvTsvConver.CSVFilePlaceProcess = Process.Start(@"..\..\..\Scraper\App.config");
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


    }
}
