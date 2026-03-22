using Core;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI;
using UI.ShopUI;

namespace GameUI 
{
    public partial class MainWindow : Window
    {
        GameManager gameSession { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gameSession = new GameManager(txtUsername.Text);
            BattleWindow bw = new BattleWindow(gameSession);
            bw.Show();
            this.Close();
        }
    }
}