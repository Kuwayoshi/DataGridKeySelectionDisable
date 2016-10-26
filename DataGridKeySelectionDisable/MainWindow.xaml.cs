using System;
using System.Collections.Generic;
using System.Data;
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

namespace DataGridKeySelectionDisable
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // データグリッドの初期化
            this.InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            // ダミーデータのテーブルを生成
            DataTable table = new DataTable();
            string[] columns = { "no", "name", "from", "type", "sex", "ability", "item", "memo" };
            table.Columns.AddRange(columns.Select(n => new DataColumn(n)).ToArray());
            table.Rows.Add("1", "mario", "kingdom", "human", "male", "fireball", "star", "hero");
            table.Rows.Add("2", "donkey", "jungle", "animal", "male", "handslap", "banana", "gorilla");
            table.Rows.Add("3", "zelda", "castle", "human", "female", "wisdom", "triforce", "princess");
            this.KeyDisableDataGrid.ItemsSource = table.DefaultView;
        }

        private void KeyDisableDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 特定のキー操作を無効化する
            if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left ||
                e.Key == Key.Right || e.Key == Key.Enter || e.Key == Key.Tab)
            {
                e.Handled = true;
            }
        }
    }
}
