using Core.Entities;
using Core.ItemsAndAbilities;
using Core.State;

namespace Core.Managers
{
    public class BattleManager // Manages Independent Battles during the game.
    {
        ///////////////
        // Constants //
        ///////////////
        private const int REWARD_MAX_VALUE = 20;
        private const int UI_ABILITIY_OPTIONS = 4;

        /////////////////
        // Constructor //
        /////////////////
        public BattleManager(Player inPlayer, Enemy inEnemy)
        {
            CurrentEnemy = inEnemy; // Set Reference
            CurrentPlayer = inPlayer; // Set Reference
            CurrentState = BattleState.PlayerTurn; // Player Turn starts first.
            Reward = new Random().Next(REWARD_MAX_VALUE); // Create a Reward
            CurrentPlayer.Mana = CurrentPlayer.MaxMana; // Refresh Players Mana.
            RollPointers(); // Set pointers for the UI so the player can get a random hand.
        }

        ////////////
        // Fields //
        ////////////
        private int _reward;

        ////////////////
        // Properties //
        ////////////////
        public Fighter CurrentEnemy { get; set; } // Reference of the Current Player Object passed in from the GameManager.
        public Fighter CurrentPlayer { get; set; } // Reference of the Current Player Object passed in from the GameManager.
        public List<int> PlayerHandIndexs { get; set; } // Gives the UI a reference for which Abilities to show from the players skills.
        public int Reward // Reward for winning a round. Cannot be less than 0.
        {
            get { return _reward; }
            set
            {
                if (value < 0)
                {
                    _reward = 0;
                }
                else
                {
                    _reward = value;
                }

            }
        }
        public Fight CurrentFight { get; set; } // Object that will run the current round of the current battle.
        public BattleState CurrentState { get; set; } // Keeps track of state for the duration of the battle
        public string lastEnemyAttackString { get; private set; } // Keeps Reference to the last Attack the enemy used for the UI.

        ////////////////////
        // Public Methods //
        ////////////////////
        public void DoPlayerMove(IAbility chosenAbility) // Takes a players ability and will play the fight with it.
        {
            if (CurrentState != BattleState.PlayerTurn) return; // Player cannot move when its not their turn.
            if (!CurrentPlayer.ValidateAbility(chosenAbility)) return; // If player cannot use the ability then continue.

            CurrentFight = new Fight(CurrentPlayer, CurrentEnemy, chosenAbility); // Create a new fight to process the damage and modify the Fighters.

            // Retrieve the fighters from the Fight
            List<Fighter> beatUpFighters = CurrentFight.GetUpdatedFighters();
            CurrentPlayer = beatUpFighters[0];
            CurrentEnemy = beatUpFighters[1];

            CheckState(); // Update State 

            if (CurrentState == BattleState.EnemyTurn)
            {
                DoEnemyMove();
                Reward -= 2; // Another round means less time to study.
            }
            else if (CurrentState == BattleState.Victory)
            {
                lastEnemyAttackString = $"{CurrentEnemy.Name} Has been debugged!";
            }
        }
        private void DoEnemyMove() // Does a fight for the enemy after the player turn. Can only be called after DoPlayerMove.
        {
            if (CurrentState != BattleState.EnemyTurn) // This shouldnt get hit.
            {
                lastEnemyAttackString = $"{CurrentEnemy.Name} Has been debugged!";
                return;
            } 

            if (CurrentEnemy is Enemy e) // Cast Enemy
            {
                IAbility chosenAbility = e.ChooseRandomAbility();
                lastEnemyAttackString = ($"{CurrentEnemy.Name} Used {chosenAbility.Name} to {chosenAbility.ToString()}"); // Update for UI.

                CurrentFight = new Fight(CurrentEnemy, CurrentPlayer, chosenAbility);
                List<Fighter> beatUpFighters = CurrentFight.GetUpdatedFighters();
                CurrentEnemy = beatUpFighters[0];
                CurrentPlayer = beatUpFighters[1];

                CheckState();
            }
        }
        public void RollPointers() // Retrieves 4 random indexes of the players Abilities that the UI can use.
        {
            PlayerHandIndexs = new List<int>();
            int abilityRange = CurrentPlayer.Abilities.Count();
            for (int i = 0; i < UI_ABILITIY_OPTIONS; i++) // Should there be more options its can be changed in constants.
            {
                // My silly algorithm for getting a list of a range of random numbers that are unique.
                bool foundNewNumber = false;
                Random rand = new Random();
                while (foundNewNumber != true)
                {
                    int newIndex = rand.Next(abilityRange);
                    if (!PlayerHandIndexs.Contains(newIndex))
                    {
                        foundNewNumber = true;
                        PlayerHandIndexs.Add(newIndex);
                    }
                }
            }
        }
        private void CheckState() // Handles Battle stat updates.
        {
            if (CurrentPlayer.Health <= 0)
            {
                CurrentState = BattleState.Defeat;

            }
            else if (CurrentEnemy.Health <= 0)
            {
                CurrentState = BattleState.Victory;
                if (CurrentPlayer is Player p) p.Money += Reward;
            }
            else if (CurrentState == BattleState.EnemyTurn)
            {
                CurrentState = BattleState.PlayerTurn;
            }
            else if (CurrentState == BattleState.PlayerTurn)
            {
                CurrentState = BattleState.EnemyTurn;
            }
        }
    }
}
