using GameData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public GameOverWindow(string determination)
        {
            InitializeComponent();
            if (determination == "w")
            {
                ShowWinner();
            }
            else if (determination == "l")
            {
                ShowLoser();
            }
            LoadRecords();
        }
        private void LoadRecords()
        {
            lstRecords.Items.Clear();
            string path = DataPasser.GeneralLocation() + "/GameRecord.txt";
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                lstRecords.Items.Add(line);
            }

        }
        private void ShowWinner()
        {
            lblResult.Content = "You Win!";
        }
        private void ShowLoser()
        {
            lblResult.Content = "YOU LOSE!";
        }
    }
}
