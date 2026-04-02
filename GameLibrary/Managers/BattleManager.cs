using Core.Entities;
using Core.ItemsAndAbilities;
using Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class BattleManager
    {
        public Fighter CurrentPlayer { get; set; }
        private int _reward;
        public int Reward
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
        public Fighter CurrentEnemy { get; set; }
        public Fight CurrentFight { get; set; }
        public BattleState CurrentState { get; set; }
        public List<int> PlayerHandIndexs { get; set; }
        public BattleManager(Player inPlayer, Enemy inEnemy)
        {
            CurrentEnemy = inEnemy;
            CurrentPlayer = inPlayer;
            CurrentState = BattleState.PlayerTurn;
            Reward = new Random().Next(20);
            RollPointers();
        }
        public void DoPlayerMove(IAbility chosenAbility)
        {
            if (CurrentState != BattleState.PlayerTurn)
            {
                return;
            }
            if (!CurrentPlayer.ValidateAbility(chosenAbility)) return;
            Console.WriteLine($"{CurrentPlayer.Name} Used {chosenAbility.Name} to {chosenAbility.ToString()}");
            CurrentFight = new Fight(CurrentPlayer, CurrentEnemy, chosenAbility);
            List<Fighter> beatUpFighters = CurrentFight.GetUpdatedFighters();
            CurrentPlayer = beatUpFighters[0];
            CurrentEnemy = beatUpFighters[1];
            CheckState();
            if (CurrentState == BattleState.EnemyTurn)
            {
                DoEnemyMove();
            }
            Reward -= 2;
        }
        private void DoEnemyMove()
        {
            if (CurrentState != BattleState.EnemyTurn)
            {
                return;
            } 
            if (CurrentEnemy is Enemy e)
            {
                IAbility chosenAbility = e.ChooseRandomAbility();
                Console.WriteLine($"{CurrentEnemy.Name} Used {chosenAbility.Name} to {chosenAbility.ToString()}");
                CurrentFight = new Fight(CurrentEnemy, CurrentPlayer, chosenAbility);
                List<Fighter> beatUpFighters = CurrentFight.GetUpdatedFighters();
                CurrentEnemy = beatUpFighters[0];
                CurrentPlayer = beatUpFighters[1];
                CheckState();
            }
        }
        public void RollPointers()
        {
            PlayerHandIndexs = new List<int>();
            int abilityRange = CurrentPlayer.Abilities.Count();
            for (int i = 0; i < 4; i++)
            {
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
            Console.WriteLine(PlayerHandIndexs);
        }
        private void CheckState()
        {
            if (CurrentPlayer.Health <= 0)
            {
                CurrentState = BattleState.Defeat;
            }
            else if (CurrentEnemy.Health <= 0)
            {
                CurrentState = BattleState.Victory;
                if (CurrentPlayer is Player p)
                {
                    p.Money += Reward;
                }
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
