using GameData;
using System.IO;
using System.Windows;

namespace UI
{
    public partial class GameOverWindow : Window
    {
        ////////////////
        // Properties //
        ////////////////
        private bool IsChris { get; set; }

        /////////////////
        // Constructor //
        /////////////////
        public GameOverWindow(bool isWin, bool isChris)
        {
            InitializeComponent();
            if (isWin)
            {
                lblResult.Content = "You Win!";
            }
            else 
            {
                lblResult.Content = "You lose..";
            }
            LoadRecords(); // Shows the player records.
            IsChris = isChris; 
        }

        /////////////
        // Methods //
        /////////////
        private void LoadRecords() // Populates the list box with the text file of game records.
        {
            lstRecords.Items.Clear();
            try
            {
                string path = DataPasser.GeneralLocation() + "/GameRecord.txt";
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    lstRecords.Items.Add(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e) // Closes the app.
        {
            if (IsChris)
            {
                ChrisWindow cw = new ChrisWindow();
                cw.Show();
            }
            this.Close();
        }
    }
}
