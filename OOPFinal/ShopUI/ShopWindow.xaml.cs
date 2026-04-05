using Core.Entities;
using Core.ItemsAndAbilities;
using Core.Managers;
using System.Windows;
using System.Windows.Controls;
using UI.Utils;

namespace UI.ShopUI
{
    public partial class ShopWindow : Window
    {
        /////////////////
        // Constructor //
        /////////////////
        public ShopWindow(GameManager inSession)
        {
            InitializeComponent();
            CurrentSession = inSession;
            CurrentPlayer = CurrentSession.CurrentPlayer;
            CurrentShop = CurrentSession.CurrentShopManager;
            CurrentSession.UpdateState(Core.State.GameState.Shop);
        }

        ////////////////
        // Properties //
        ////////////////
        private GameManager CurrentSession { get; set; }
        private Player CurrentPlayer { get; set; }
        private ShopManager CurrentShop { get; set; }

        /////////////
        // Methods //
        /////////////
        private void UpdateUI() // Updates UI with all dynamic elements
        {
            // Normal labels to be updated.
            lblRoundInfo.Content = $"Round {CurrentSession.Round + 1}";
            lblPlayerMoney.Content = $"Time Left To Study {CurrentPlayer.Money} hrs";
            lblPlayerAttack.Content = $"⚔: {CurrentPlayer.Attack}";
            lblPlayerDefense.Content = $"⛉: {CurrentPlayer.Defense}";
            btnRoll.Content = $"Search Google {CurrentShop.CurrentRollCost} hrs";

            PopulateAbilitiesList(); // Shows the users current abilities

            // Figures out if it needs to show the last round
            if (CurrentSession.Round == CurrentSession.AllEnemies.Count()) lblUpcomingFight.Content = "Game Over!";
            else lblUpcomingFight.Content = $"Next Class: {CurrentSession.AllEnemies[CurrentSession.Round].ErrorType}";

            ShowShopItems(); // Uses the ShopManagers items to populate the UI.
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // Handles clean up when window is done.
        {
            CurrentSession.OnShopOver(CurrentPlayer); // Passes updated player to the Manager
            BattleWindow bw = new BattleWindow(CurrentSession);
            bw.Show();
        }
        private void Window_Activated(object sender, EventArgs e) // Updates UI on Load
        {
            UpdateUI();
        }
        private void btnBattle_Click(object sender, RoutedEventArgs e) // Player indicates they want to go to the next battle.
        {
            this.Close();
        }
        private void PopulateAbilitiesList() // Takes all abilities from player, and puts them into the list box so they can see their "deck".
        {
            lstPlayerSkill.Items.Clear();
            foreach (IAbility ia in CurrentPlayer.Abilities )
            {
                lstPlayerSkill.Items.Add(ia.ToString());
            }
        }
        private void btnRoll_Click(object sender, RoutedEventArgs e)  // Allows player to cycle through a new list of abilities if they can afford it.
        {
            if (CurrentPlayer.CheckCanAfford(CurrentShop.CurrentRollCost)) // cannot roll if you cant afford it.
            {
                CurrentPlayer.Money -= CurrentShop.CurrentRollCost;
                CurrentShop.Roll();
                UpdateUI();
            }
        }
        private void ShowShopItems() // Sets the UI of the shop items to match the managers Items
        {
            try
            {
                txtAbility_0.Content = CurrentShop.AvailableAbilities[0].Name;
                txtAbility_1.Content = CurrentShop.AvailableAbilities[1].Name;
                txtAbility_2.Content = CurrentShop.AvailableAbilities[2].Name;

                btnAbility_0.Content = $"Learn (Costs {CurrentShop.AvailableAbilities[0].Price}h)";
                btnAbility_1.Content = $"Learn (Costs {CurrentShop.AvailableAbilities[1].Price}h)";
                btnAbility_2.Content = $"Learn (Costs {CurrentShop.AvailableAbilities[2].Price}h)";

                btnStatItem_0.Content = $"Learn (Costs {CurrentShop.AvailableAbilities[0].Price}h)";
                btnStatItem_1.Content = $"Learn (Costs {CurrentShop.AvailableAbilities[1].Price}h)";

                imgAbility_0.Source = SpriteHandler.CreateSprite(CurrentShop.AvailableAbilities[0].Sprite);
                imgAbility_1.Source = SpriteHandler.CreateSprite(CurrentShop.AvailableAbilities[1].Sprite);
                imgAbility_2.Source = SpriteHandler.CreateSprite(CurrentShop.AvailableAbilities[2].Sprite);

                imgAbility_0.ToolTip = CurrentShop.AvailableAbilities[0].ToString();
                imgAbility_1.ToolTip = CurrentShop.AvailableAbilities[1].ToString();
                imgAbility_2.ToolTip = CurrentShop.AvailableAbilities[2].ToString();

                txtStatItem_0.Content = CurrentShop.AvailableStatItems[0].Name;
                txtStatItem_1.Content = CurrentShop.AvailableStatItems[1].Name;

                imgStatItem_0.Source = SpriteHandler.CreateSprite(CurrentShop.AvailableStatItems[0].Sprite);
                imgStatItem_1.Source = SpriteHandler.CreateSprite(CurrentShop.AvailableStatItems[1].Sprite);

                imgStatItem_0.ToolTip = CurrentShop.AvailableStatItems[0].ToString();
                imgStatItem_1.ToolTip = CurrentShop.AvailableStatItems[1].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void TryLearn(string type, int index) // Handles the logic for what happens when an ability or item is bought.
        {
            if (type == "btnStatItem")
            {
                IShopItem stat = CurrentShop.AvailableStatItems[index];
                CurrentPlayer.TryBuy(stat);
            }
            else if ( type == "btnAbility")
            {
                IShopItem ability = CurrentShop.AvailableAbilities[index];
                CurrentPlayer.TryBuy(ability);
            }
            else
            {
                MessageBox.Show("Invalid Type used for learn button click");
            }
            UpdateUI();
        }
        private void Learn_click(object sender, RoutedEventArgs e) // Determines item reference in manager and tries to apply it to the player.
        {
            if (sender is Button b)
            {
                try
                {
                    string[] splitData = b.Name.Split("_");
                    string itemType = splitData[0];
                    int itemIndex = Convert.ToInt32(splitData[1]);
                    TryLearn(itemType, itemIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Getting Ability\n{ex.Message}");
                }
            }
        }
    }
}
