using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp13_listview2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public System.Collections.ObjectModel.ObservableCollection<ZipRecord> ZipRecords { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.ZipRecords = new System.Collections.ObjectModel.ObservableCollection<ZipRecord>();
            listView.DataContext = this.ZipRecords;
        }

        /// <summary>
        /// CSVファイル読み込み
        /// </summary>
        /// <param name="filePath">CSVファイルパス</param>
        private void ReadCsv(string filePath)
        {
            this.ZipRecords.Clear();

            var parser =
                new Microsoft.VisualBasic.FileIO.TextFieldParser(filePath, Encoding.Default);
            using (parser)
            {
                // 「,」区切りのデータとして処理する
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");

                try
                {
                    //int i = 0;// debug

                    // ファイルの終わりまで繰り返す
                    while (parser.EndOfData == false)
                    {
                        // 一行分読み込み
                        string[] buf = parser.ReadFields();


                        this.ZipRecords.Add(new ZipRecord
                        {
                            Code = buf[0],
                            ZipOld = buf[1],
                            Zip = buf[2],
                            StateKana = buf[3],
                            CityKana = buf[4],
                            TownKana = buf[5],
                            State = buf[6],
                            City = buf[7],
                            Town = buf[8],
                            Flag1 = buf[9],
                            Flag2 = buf[10],
                            Flag3 = buf[11],
                            Flag4 = buf[12],
                            Flag5 = buf[13],
                            Flag6 = buf[14],
                        });

                        /*
                        i++;// debug
                        string istring = i.ToString();// debug
                        textBlock.Text = "parserが"+istring+"回回されました";// debug
                        */
                    }
                }
                catch
                {
                    throw new Exception("CSV読み込みでエラー！");
                }
            }
        }

        private void openMenu_Click(object sender, RoutedEventArgs e)
        {
            //textBlock.Text = "openMenu_Clickが実行されました";
            var dlg = new Microsoft.Win32.OpenFileDialog();

            // フィルタ設定
            dlg.Filter = "CSVファイル(*.csv)|*.csv|テキストファイル(*.txt)|*.txt|全てのファイル(*.*)|*.*";
            // フィルタの1番目(CSV)を選択状態にする
            dlg.FilterIndex = 1;

            // ファイルを開くダイアログ表示
            if (dlg.ShowDialog() == true)
            {
                this.IsEnabled = false;

                // CSV読み込み
                ReadCsv(dlg.FileName);

                this.IsEnabled = true;
            }
        }

        /// <summary>
        /// メニュー「終了」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitMenu_Click(object sender, RoutedEventArgs e)
        {
            // プログラム終了
            this.Close();
        }

        /// <summary>
        /// メニュー「クリア」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearMenu_Click(object sender, RoutedEventArgs e)
        {
            // 一覧をクリア
            this.ZipRecords.Clear();
        }
    }
}
