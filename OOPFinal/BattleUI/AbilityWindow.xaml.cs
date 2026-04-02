using Core.Managers;
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
using UI.Utils;

namespace UI.BattleUI
{
    public partial class AbilityWindow : Window
    {
        private BattleManager ManagerRef { get; set; }
        public event EventHandler? UpdateParentUI;
        public AbilityWindow(BattleManager inManagerRef)
        {
            InitializeComponent();
            ManagerRef = inManagerRef;
            UpdateUI();
        }
        public void UpdateUI()
        {
            // Update the cards
            txtAbility_0.Content = ManagerRef.CurrentPlayer.Abilities[0];
            txtAbility_1.Content = ManagerRef.CurrentPlayer.Abilities[1];
            txtAbility_2.Content = ManagerRef.CurrentPlayer.Abilities[2];
            txtAbility_3.Content = ManagerRef.CurrentPlayer.Abilities[3];
            imgAbility_0.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[0].Sprite);
            imgAbility_1.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[0].Sprite);
            imgAbility_2.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[0].Sprite);
            // Update the parent

        }
        public void OnUpdateParentUI(EventArgs e)
        {
            UpdateParentUI.Invoke(this, e);
        }
        
        private void Use_click(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                try
                {
                    string[] splitData = b.Name.Split("_");
                    string itemType = splitData[0];
                    int itemIndex = Convert.ToInt32(splitData[1]);
                    Console.Write(ManagerRef.CurrentPlayer.Name);
                    ManagerRef.DoPlayerMove(ManagerRef.CurrentPlayer.Abilities[itemIndex]);
                    ManagerRef.CurrentPlayer.Abilities.Shuffle();
                    ManagerRef.UpdatePlayerHand();
                    UpdateUI();
                    OnUpdateParentUI(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Getting Ability\n{ex.Message}");
                }
            }
        }
    }
}
