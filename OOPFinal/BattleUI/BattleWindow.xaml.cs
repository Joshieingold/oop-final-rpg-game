using Core.Entities;
using Core.Managers;
using Core.State;
using System.Windows;
using UI.ShopUI;
using UI.Utils;

namespace UI
{
    public partial class BattleWindow : Window
    {
        GameManager CurrentSession { get; set; }
        private Player currentPlayer {get; set;}
        private Enemy currentEnemy {get; set;}

        public BattleWindow(GameManager inManager) // Uses reference for the player, this will be useful for the shop
        {
            InitializeComponent();
            CurrentSession = inManager;

            CurrentSession.UpdateState(GameState.Battle);
            // Initialize the current Variables
            if (inManager.CurrentBattleManager.CurrentPlayer is Player p)
            {
                currentPlayer = p;
            }
            if (inManager.CurrentBattleManager.CurrentEnemy is Enemy e)
            {
                currentEnemy = e;
            }

            // Update UI
            UpdateUI();
        }

        // Updates the UI from the childs ping
        private void AbilityWindow_UiUpdate(object sender, EventArgs e)
        {
            UpdateUI();
        }
        // Updates all UI Elements with reference data
        private void UpdateUI()
        {
            //lblTurn.Content = CurrentSession.CurrentBattleManager.CurrentFight.ToString();
            SetEnemyData();
            SetPlayerData();
        }

        // Sets UI Elements for the Enemy 
        private void SetEnemyData()
        {
            picEnemySprite.Source = SpriteHandler.CreateSprite(currentEnemy.EnemySprite); // TEMP, THIS SHOULD BE SET BASED ON THE ENEMY NAME 
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
            picPlayerSprite.Source = SpriteHandler.CreateSprite(currentPlayer.PlayerSprite);
            lblTurn.Content = CurrentSession.CurrentBattleManager.CurrentState.ToString();
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ShopWindow sw = new ShopWindow(CurrentSession);
            sw.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentSession.CurrentBattleManager.DoPlayerMove(currentPlayer.Abilities[0]);
            UpdateUI();
        }
    }
}
