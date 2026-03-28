using Core;
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
            foreach (IAbility a in CurrentPlayer.Abilities)
            {
                Console.WriteLine(a.ToString());
            }
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
                lblUpcomingFight.Content = $"Next Class: {CurrentSession.AllEnemies[CurrentSession.Round].ErrorType}"; // THIS WILL CAUSE AN EXEPTION ON
            }

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
                CurrentShop.IncreaseRollCost();
                UpdateUI();
                HandleRoll();
            }
        }
    }
}
