using Core.Characters;
using Core.Entities;
using Core.State;
using Core.Utils;
using System;
using System.Collections.Generic;
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
    public partial class BattleWindow : Window
    {
        Player currentPlayer;
        public BattleWindow(ref Player inPlayer)
        {
            currentPlayer = inPlayer;
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            Enemy notMe = ObjectFactory.CreateEnemy(ProgLang.Javascript);
            PlayerLabel.Content = currentPlayer.ToString();
            EnemyLabel.Text = notMe.ToString();
            Battle thisFight = new Battle(currentPlayer, notMe);
        }
    }
}
