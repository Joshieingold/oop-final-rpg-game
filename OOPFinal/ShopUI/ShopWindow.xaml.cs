using Core.Entities;
using Core.ItemsAndAbilities;
using Core.Managers;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.Utils;

namespace UI.ShopUI
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        GameManager CurrentSession { get; set; }
        Player CurrentPlayer { get; set; }
        ShopManager CurrentShop { get; set; }
        public ShopWindow(GameManager inSession)
        {
            InitializeComponent();
            CurrentSession = inSession;
            CurrentPlayer = CurrentSession.CurrentPlayer;
            CurrentShop = CurrentSession.CurrentShopManager;
            // This should all be moved to onload
            CurrentSession.UpdateState(Core.State.GameState.Shop);
            foreach (IAbility a in CurrentPlayer.Abilities)
            {
                Console.WriteLine(a.ToString());
            }
            imgAbility_1.Source = SpriteHandler.CreateSprite("ShopItems/PlaceHolder.png");
        }
        private void HandleRoll()
        {
            // Make the shop items go to next
            return;
        }
        private void UpdateUI()
        {
            lblRoundInfo.Content = $"Round {CurrentSession.Round + 1}";
            lblPlayerMoney.Content = $"Time Left To Study {CurrentPlayer.Money} hrs";
            lblPlayerAttack.Content = $"⚔: {CurrentPlayer.Attack}";
            lblPlayerDefense.Content = $"⛉: {CurrentPlayer.Defense}";
            
            btnRoll.Content = $"Search Google {CurrentShop.CurrentRollCost} hrs";
            PopulateAbilitiesList();
            if (CurrentSession.Round == CurrentSession.AllEnemies.Count())
            {
                lblUpcomingFight.Content = "Game Over!";
            }
            else
            {
                lblUpcomingFight.Content = $"Next Class: {CurrentSession.AllEnemies[CurrentSession.Round].ErrorType}"; // THIS WILL CAUSE AN EXEPTION ON Round 8
            }
            ShowShopItems();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CurrentSession.OnShopOver(CurrentPlayer);
            BattleWindow bw = new BattleWindow(CurrentSession);
            bw.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void btnBattle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PopulateAbilitiesList()
        {
            lstPlayerSkill.Items.Clear();
            foreach (IAbility ia in CurrentPlayer.Abilities )
            {
                lstPlayerSkill.Items.Add(ia.ToString());
            }
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPlayer.CheckCanAfford(CurrentShop.CurrentRollCost))
            {
                CurrentPlayer.Money -= CurrentShop.CurrentRollCost;
                CurrentShop.Roll();
                UpdateUI();
                HandleRoll();
            }
        }
        private void ShowShopItems()
        {
            txtAbility_0.Content = CurrentShop.AvailableAbilities[0].Name;
            txtAbility_1.Content = CurrentShop.AvailableAbilities[1].Name;
            txtAbility_2.Content = CurrentShop.AvailableAbilities[2].Name;

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
        private void TryLearn(string type, int index)
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

        private void Learn_click(object sender, RoutedEventArgs e)
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
