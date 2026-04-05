using Core.Managers;
using System.Windows;
using UI;

namespace GameUI 
{
    public partial class MainWindow : Window
    {
        /////////////////
        // Constructor //
        /////////////////
        public MainWindow()
        {
            InitializeComponent();
        }

        ////////////////
        // Properties //
        ////////////////
        public GameManager gameSession { get; set; } // Main Game Session Reference that will be used in the life cycle of the app.

        /////////////
        // Methods //
        /////////////
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gameSession = new GameManager(txtUsername.Text, (bool)radMale.IsChecked);
                BattleWindow bw = new BattleWindow(gameSession);
                bw.Show();
                this.Close();
            }
            catch
            {
                return; // If they do something wrong just dont let them progress.
            }
        }
    }
}