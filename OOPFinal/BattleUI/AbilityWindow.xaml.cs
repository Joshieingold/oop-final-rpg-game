using Core.Managers;
using System.Windows;
using System.Windows.Controls;
using UI.Utils;

namespace UI.BattleUI
{
    public partial class AbilityWindow : Window // Window show the abilities the player can use
    {
        /////////////////
        // Constructor //
        /////////////////
        public AbilityWindow(BattleManager inManagerRef)
        {
            InitializeComponent();
            ManagerRef = inManagerRef;
            UpdateUI();
        }

        ////////////////
        // Properties //
        ////////////////
        private BattleManager ManagerRef { get; set; }
        public event EventHandler? UpdateParentUI; // Requests to update the main window when a button is clicked here.
        
        /////////////
        // Methods //
        /////////////
        public void UpdateUI() // Updates the UI Based on data in the
        {
            // Update the cards texts using the game managers indexes.
            txtAbility_0.Content = ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[0]];
            txtAbility_1.Content = ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[1]];
            txtAbility_2.Content = ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[2]];
            txtAbility_3.Content = ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[3]];

            // Update the cards images using the game managers indexes.
            imgAbility_0.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[0]].Sprite);
            imgAbility_1.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[1]].Sprite);
            imgAbility_2.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[2]].Sprite);
            imgAbility_3.Source = SpriteHandler.CreateSprite(ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[3]].Sprite);
        }
        public async void OnUpdateParentUI(EventArgs e) // Just tells the main battle window to update its ui
        {
            UpdateParentUI.Invoke(this, e);
        }
        
        private void Use_click(object sender, RoutedEventArgs e) // Determines the button clicked based on x:name and trys to use it.
        {
            if (sender is Button b)
            {
                try
                {
                    string[] splitData = b.Name.Split("_");
                    int itemIndex = Convert.ToInt32(splitData[1]);

                    ManagerRef.DoPlayerMove(ManagerRef.CurrentPlayer.Abilities[ManagerRef.PlayerHandIndexs[itemIndex]]); // Use that ability to attack
                    ManagerRef.RollPointers(); // Shuffle hand

                    // Update this and parent UI
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
