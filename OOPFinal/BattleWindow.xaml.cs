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
        private Battle thisFight { get; set; }

        public BattleWindow(ref Player inPlayer)
        {
            InitializeComponent();
            currentPlayer = inPlayer;
            currentEnemy = ObjectFactory.CreateEnemy(ProgLang.Javascript);
            PlayerLabel.Content = currentPlayer.ToString();
            SetEnemyData();
            thisFight = new Battle(currentPlayer, currentEnemy);
        }

        private void SetEnemyData( )
        {
            lblEnemyName.Content= currentEnemy.Name;
            progEnemyHealth.Maximum = currentEnemy.MaxHealth;
            progEnemyHealth.Minimum = 0;
            progEnemyHealth.Value = currentEnemy.Health;
            lblEnemyAtk.Content += currentEnemy.Attack.ToString();
            lblEnemyDef.Content += currentEnemy.Defense.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Hello");
            thisFight.PlayerAttack(currentPlayer.Abilities[0]);
            SetEnemyData();
        }
    }
}
