using Core.Entities;
using Core.Managers;
using Core.State;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UI.BattleUI;
using UI.ShopUI;
using UI.Utils;

namespace UI
{
    public partial class BattleWindow : Window
    {
        private GameManager CurrentSession { get; set; }
        private Player currentPlayer {get; set;}
        private Enemy currentEnemy {get; set;}
        public AbilityWindow PlayerAbilities { get; set; }

        public BattleWindow(GameManager inManager) // Uses reference for the player, this will be useful for the shop
        {
            InitializeComponent();
            CurrentSession = inManager;
            CurrentSession.UpdateState(GameState.Battle);
            PlayerAbilities = new AbilityWindow(CurrentSession.CurrentBattleManager);
            PlayerAbilities.UpdateParentUI += OnRequestUpdateUI;
            PlayerAbilities.Show();

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
            MoveWindowLocations();
            UpdateUI();
        }
        private async void OnRequestUpdateUI(object? sender, EventArgs e)
        {
            await DisplayEnemyAttack();
            UpdateUI();

        }
        private void MoveWindowLocations()
        {
            int heightOffsetValue = 200;
            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = (SystemParameters.WorkArea.Height - (this.Height + heightOffsetValue - 50)) / 2;
            PlayerAbilities.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            PlayerAbilities.Top = (SystemParameters.WorkArea.Height - (this.Height - heightOffsetValue - PlayerAbilities.Height )) ;
        }

        // Updates the UI from the childs ping
        private void AbilityWindow_UiUpdate(object sender, EventArgs e)
        {
            UpdateUI();
        }
        // Updates all UI Elements with reference data
        private void UpdateUI()
        {
            SetEnemyData();
            SetPlayerData();
        }

        // Sets UI Elements for the Enemy 
        private void SetEnemyData()
        {
            picEnemySprite.Source = SpriteHandler.CreateSprite(currentEnemy.EnemySprite);
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
            lblPlayerAttack.Content = $"⚔: {currentPlayer.Attack.ToString()}";
            lblPlayerDefense.Content = $"⛉: {currentPlayer.Defense.ToString()}";
            progPlayerHealth.Maximum = currentPlayer.MaxHealth;
            progPlayerHealth.Minimum = 0;
            progPlayerHealth.Value = currentPlayer.Health;
            progPlayerMana.Maximum = currentPlayer.MaxMana;
            progPlayerMana.Minimum = 0;
            progPlayerMana.Value = currentPlayer.Mana;
        }
        private async Task DisplayEnemyAttack()
        {
            var bubbleBrush = (SolidColorBrush)this.FindResource("bubbleColor");
            lblEnemyAbilityText.Background = bubbleBrush;
            lblEnemyAbilityText.Content = CurrentSession.CurrentBattleManager.GetLastAttackString();
            await Task.Delay(1500);
            lblEnemyAbilityText.Background = Brushes.Transparent;
            lblEnemyAbilityText.Content = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PlayerAbilities.Close();
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
