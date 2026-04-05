using Core.Entities;
using Core.Managers;
using Core.State;
using System.Windows;
using System.Windows.Media;
using UI.BattleUI;
using UI.ShopUI;
using UI.Utils;

namespace UI
{
    public partial class BattleWindow : Window
    {
        ///////////////
        // Constants //
        ///////////////
        private const int WINDOW_OFFSET = 200;
        private const int MESSAGE_WINDOW_TIMER = 1500;
        private const int GAME_ROUNDS = 8;

        
        /////////////////
        // Constructor //
        /////////////////
        public BattleWindow(GameManager inManager) // Uses reference for the player, this will be useful for the shop
        {
            InitializeComponent();
            // Setting up the component.
            CurrentSession = inManager;
            CurrentSession.UpdateState(GameState.Battle);

            // Initializing the ability selection window.
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

        ////////////////
        // Properties //
        ////////////////
        public AbilityWindow PlayerAbilities { get; set; } // Window that player chooses attacks from.
        private GameManager CurrentSession { get; set; } // Reference to the games session.
        private Player currentPlayer {get; set;} // Current player that is derived from the game session.
        private Enemy currentEnemy {get; set;} // Current player that is derived from the game session.

        /////////////
        // Methods //
        /////////////
        private async void OnRequestUpdateUI(object? sender, EventArgs e) // Event listener method that will update all screen UI.
        {
            await DisplayEnemyAttack();
            UpdateUI();
        }
        private void MoveWindowLocations() // Places window locations so they can both be visable and consitently in the right spot.
        {
            int heightOffsetValue = WINDOW_OFFSET;
            this.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            this.Top = (SystemParameters.WorkArea.Height - (this.Height + heightOffsetValue - 50)) / 2;
            PlayerAbilities.Left = (SystemParameters.WorkArea.Width - this.Width) / 2;
            PlayerAbilities.Top = (SystemParameters.WorkArea.Height - (this.Height - heightOffsetValue - PlayerAbilities.Height )) ;
        }

        // Updates all UI Elements with reference data
        private void UpdateUI()
        {
            SetEnemyData();
            SetPlayerData();
            if (CurrentSession.CurrentBattleManager.CurrentState == BattleState.Defeat || CurrentSession.CurrentBattleManager.CurrentState == BattleState.Victory)
            {
                this.Close();
            }
        }
        private void SetEnemyData() // Sets UI Elements for the Enemy 
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

        private void SetPlayerData() // Sets UI Elements for the player
        {
            picPlayerSprite.Source = SpriteHandler.CreateSprite(currentPlayer.PlayerSprite);
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
            lblReward.Content = $"Remaining Class Time: {CurrentSession.CurrentBattleManager.Reward}";
        }
        private async Task DisplayEnemyAttack() // Shows a window with attack message that will disappear after a timer.
        {
            // Attack message is shown.
            var bubbleBrush = (SolidColorBrush)this.FindResource("bubbleColor");
            lblEnemyAbilityText.Background = bubbleBrush;
            lblEnemyAbilityText.Content = CurrentSession.CurrentBattleManager.lastEnemyAttackString;
            await Task.Delay(MESSAGE_WINDOW_TIMER);

            // Attack message is cleaned up.
            lblEnemyAbilityText.Background = Brushes.Transparent;
            lblEnemyAbilityText.Content = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // Handles cleaning up when window is closing.
        {
            PlayerAbilities.Close(); // Ability window is not used in the shop.

            if (CurrentSession.CurrentBattleManager.CurrentState == BattleState.Victory)
            {
                if (CurrentSession.Round == GAME_ROUNDS) // Checks to see if that was the final round of the game
                {
                    CurrentSession.UpdateState(GameState.Victory);
                    GameOverWindow winner = new GameOverWindow(true); // is a win so it takes in true.
                    winner.Show();
                }
                else
                {
                    ShopWindow sw = new ShopWindow(CurrentSession);
                    sw.Show();
                }
            }
            else if (CurrentSession.CurrentBattleManager.CurrentState == BattleState.Defeat) // Player lost and it is game over
            {
                CurrentSession.UpdateState(GameState.Defeat);
                GameOverWindow loser = new GameOverWindow(false); // Not a win so takes in false.
                loser.Show();
            }
        }
    }
}
