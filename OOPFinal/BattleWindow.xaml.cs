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
        private Player currentPlayer {get; set;}
        private Enemy currentEnemy {get; set;}

        public BattleWindow(ref Player inPlayer)
        {
            currentPlayer = inPlayer;
            currentEnemy = ObjectFactory.CreateEnemy(ProgLang.Javascript);
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            PlayerLabel.Content = currentPlayer.ToString();
            SetEnemyData(currentEnemy);
            Battle thisFight = new Battle(currentPlayer, currentEnemy);
        }
        private void SetEnemyData(Enemy inEnemy )
        {
            lblEnemyName.Content= inEnemy.Name;
            progEnemyHealth.Maximum = inEnemy.MaxHealth;
            progEnemyHealth.Minimum = 0;
            progEnemyHealth.Value = inEnemy.Health;
            lblEnemyAtk.Content += inEnemy.Attack.ToString();
            lblEnemyDef.Content += inEnemy.Defense.ToString();
        }
    }
}
