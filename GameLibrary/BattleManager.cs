using Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BattleManager
    {
        public Fighter CurrentPlayer { get; set; }
        public Fighter CurrentEnemy { get; set; }
        public Fight CurrentFight { get; set; }
        public BattleState CurrentState { get; set; }
        public BattleManager(Player inPlayer, Enemy inEnemy)
        {
            CurrentEnemy = inEnemy;
            CurrentPlayer = inPlayer;
            CurrentState = BattleState.PlayerTurn;
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
        private void CheckState()
        {
            if (CurrentPlayer.Health <= 0)
            {
                CurrentState = BattleState.Defeat;
            }
            else if (CurrentEnemy.Health <= 0)
            {
                CurrentState = BattleState.Victory;
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
        private void GetUpdatedFighters()
        {

        }
        private Fighter RequestPlayer()
        {
            return CurrentPlayer;
        }
    }
}
