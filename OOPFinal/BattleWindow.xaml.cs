using Core.Characters;
using Core.Entities;
using Core.State;
using Core.Utils;
using GameData;
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
using UI.Helpers;


// ISSUES //
// Enemy sprite is static and should be based on the character name
// Created Enemy is not informed on anything, it just creates JS enemies
namespace UI
{
    public partial class BattleWindow : Window
    {
        private Player currentPlayer {get; set;}
        private Enemy currentEnemy {get; set;}
        private Battle thisFight { get; set; }

        public BattleWindow(ref Player inPlayer) // Gets reference for the player, this will be useful for the shop
        {
            InitializeComponent();

            // Initialize the current Variables
            currentPlayer = inPlayer;
            currentEnemy = ObjectFactory.CreateEnemy(ProgLang.Javascript); // This needs to be based on some round system
            thisFight = new Battle(currentPlayer, currentEnemy);

            // Update UI
            UpdateUI();
        }

        // Updates all UI Elements with reference data
        private void UpdateUI()
        {
            lblTurn.Content = thisFight.State.ToString();
            SetEnemyData();
            SetPlayerData();
        }

        // Sets UI Elements for the Enemy 
        private void SetEnemyData()
        {
            picEnemySprite.Source = SpriteHandler.CreateSprite("JavascriptGirl.png"); // TEMP, THIS SHOULD BE SET BASED ON THE ENEMY NAME 
            lblTurn.Content = thisFight.State.ToString();
            lblEnemyName.Content= currentEnemy.Name;
            progEnemyHealth.Maximum = currentEnemy.MaxHealth;
            progEnemyHealth.Minimum = 0;
            progEnemyHealth.Value = currentEnemy.Health;
            lblEnemyHealth.Content = $"{currentEnemy.Health}/{currentEnemy.MaxHealth}";
            lblEnemyAtk.Content = $"⚔: {currentEnemy.Attack.ToString()}";
            lblEnemyDef.Content = $"⛉: {currentEnemy.Defense.ToString()}";
        }

        // Sets UI Elements for the player
        private void SetPlayerData()
        {
            picPlayerSprite.Source = SpriteHandler.CreateSprite("Player.png");
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
    }
}
