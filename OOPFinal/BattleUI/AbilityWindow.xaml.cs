using Core.Abilities;
using Core.Characters;
using Core.Entities;
using Core.State;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI.BattleUI
{
    /// <summary>
    /// Interaction logic for AbilityWindow.xaml
    /// </summary>
    public partial class AbilityWindow : Window
    {
        Battle BattleLink { get; set; }
        public event EventHandler UiUpdate;
        public AbilityWindow(Battle inBattle)
        {
            InitializeComponent();
            BattleLink = inBattle;
            AddAllButtons();

        }
        private Button CreateAbilityButton(Ability inAbility)
        {
            Button thisButton = new Button();
            thisButton.Content = $"{inAbility.Name}\nMana: {inAbility.ManaCost}\nDmg: {inAbility.Power}";
            thisButton.Margin = new Thickness(0,20,20,20);
            thisButton.Foreground = (Brush)FindResource("forgroundColor");
            thisButton.Background = (Brush)FindResource("bubbleColor");
            thisButton.BorderBrush = null;
            thisButton.Width = 150;
            thisButton.Click+= (sender, args) => 
            {
                BattleLink.PlayerAttack(inAbility);
                UiUpdate?.Invoke(this, EventArgs.Empty);
            };
            return thisButton;
        }
        private void AddAllButtons()
        {
            foreach(Ability thisAbility in BattleLink.CurrentPlayer.Abilities)
            {
                Button currentButton = CreateAbilityButton(thisAbility);
                pnlAbilityButtons.Children.Add(currentButton);
            }
        }
    }
}
