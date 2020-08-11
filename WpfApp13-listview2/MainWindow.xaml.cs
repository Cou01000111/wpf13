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
            listView.ItemsSource = this.ZipRecords;
            BindingOperations.EnableCollectionSynchronization(this.ZipRecords, new object());
        }

        /// <summary>
        /// データ読み込み中の画面表示
        /// </summary>
        /// <param name="loading">データ読み込み中の時にtrue, 読み込み終わったらfalseを設定する</param>
        private void SetLoadingUI(bool loading)
        {
            if (loading)
            {
                // 処理中

                // 画面全体を無効化
                this.IsEnabled = !loading;
                // 処理中メッセージを表示
                loadingText.Visibility = Visibility.Visible;
                // リストを隠す
                listView.Visibility = Visibility.Collapsed;
                // タスクバーアイコンを処理中表示にする
                taskbarInfo.ProgressState = System.Windows.Shell.TaskbarItemProgressState.Indeterminate;
            }
            else
            {
                // 処理終り

                // 画面全体を有効化
                this.IsEnabled = !loading;
                // 処理中メッセージを隠す
                loadingText.Visibility = Visibility.Collapsed;
                // リストを表示
                listView.Visibility = Visibility.Visible;
                // タスクバーアイコンを通常に戻す
                taskbarInfo.ProgressState = System.Windows.Shell.TaskbarItemProgressState.None;
            }
        }

        /// <summary>
        /// CSVファイル読み込みタスク
        /// </summary>
        /// <param name="filePath">CSVファイルパス</param>
        /// <returns></returns>
        private Task ReadCsvTask(string filePath)
        {
            return Task.Run(() => { ReadCsv(filePath); });
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
                    }
                }
                catch
                {
                    throw new Exception("CSV読み込みでエラー！");
                }
            }
        }

        private async void openMenu_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();

            // フィルタ設定
            dlg.Filter = "CSVファイル(*.csv)|*.csv|テキストファイル(*.txt)|*.txt|全てのファイル(*.*)|*.*";
            // フィルタの1番目(CSV)を選択状態にする
            dlg.FilterIndex = 1;

            // ファイルを開くダイアログ表示
            if (dlg.ShowDialog() == true)
            {
                SetLoadingUI(true);

                // CSV読み込み
                await ReadCsvTask(dlg.FileName);

                SetLoadingUI(false);
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
