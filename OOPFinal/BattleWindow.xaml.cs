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
            thisFight = new Battle(currentPlayer, currentEnemy);
            lblTurn.Content = thisFight.State.ToString();
            SetEnemyData();
            SetPlayerData();
        }

        private void SetEnemyData()
        {
            lblTurn.Content = thisFight.State.ToString();
            lblEnemyName.Content= currentEnemy.Name;
            progEnemyHealth.Maximum = currentEnemy.MaxHealth;
            progEnemyHealth.Minimum = 0;
            progEnemyHealth.Value = currentEnemy.Health;
            lblEnemyHealth.Content = $"{currentEnemy.Health}/{currentEnemy.MaxHealth}";
            lblEnemyAtk.Content = $"⚔: {currentEnemy.Attack.ToString()}";
            lblEnemyDef.Content = $"⛉: {currentEnemy.Defense.ToString()}";
        }
        private void SetPlayerData()
        {
            lblTurn.Content = thisFight.State.ToString();
            lblPlayerName.Content = currentPlayer.Name;
            lblPlayerHealth.Content = $"{currentPlayer.Health}/{currentPlayer.MaxHealth}";
            lblPlayerMana.Content = $"{currentPlayer.Mana}/{currentPlayer.MaxMana}";
            progPlayerHealth.Maximum = currentPlayer.MaxHealth;
            progPlayerHealth.Minimum = 0;
            progPlayerHealth.Value = currentPlayer.Health;
            progPlayerMana.Maximum = currentPlayer.MaxMana;
            progPlayerMana.Minimum = 0;
            progPlayerMana.Value = currentPlayer.Mana;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thisFight.PlayerAttack(currentPlayer.Abilities[0]);
            SetEnemyData();
            SetPlayerData();
        }
    }
}
