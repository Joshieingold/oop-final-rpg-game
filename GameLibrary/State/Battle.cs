using Core.Abilities;
using Core.Characters;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.State
{
    // Should add an all nighter mode that allows the user to have infinite mana if they cannot use any ability but it will cost % health every round.
    public class Battle
    {
        public Player CurrentPlayer { get; }
        public Enemy CurrentEnemy { get; }
        public BattleState State { get; set; } = BattleState.PlayerTurn; // Initialized for the players turn first
        public int RoundNumber { get; private set; } = 1;
        public Battle(Player inPlayer, Enemy inEnemy)
        {
            CurrentPlayer = inPlayer;
            CurrentEnemy = inEnemy;
        }
        public void PlayerAttack(Ability chosenAbility)
        {
            if (State != BattleState.PlayerTurn)
            {
                // Show Error Message;
                Console.WriteLine("It's not your turn");
                return;
            }
            CurrentPlayer.UseAttack(chosenAbility, CurrentEnemy); // PROBABLY NEED TO USE REF HERE BUT HAD TO REMOVE IT TO GET THE CODE WORKING WE WILL SEE WHEN THE GAME IS ACTUALLY IN A PLAYABLE STATE
            RoundNumber++;
            CheckState();
        }

        private void EnemyAttack()
        {
            // Probably want to make it delay here at some point 
            CurrentEnemy.UseAttack(CurrentPlayer); // SAME REF STUFF HERE
            CheckState();
        }

        // Helpers
        private void TryAwardPlayerAbility()
        {
            Ability newAbility = CurrentEnemy.RequestAbility();
            if (! (CurrentPlayer.Abilities).Contains(newAbility))
            {
                Console.WriteLine($"You gained {newAbility.ToString()}");
                CurrentPlayer.Abilities.Add(newAbility);
            }
        }

        private void CheckState()
        {
            if (CurrentPlayer.IsAlive == false)
            {
                State = BattleState.Defeat;
            }
            else if (CurrentEnemy.IsAlive == false)
            {
                TryAwardPlayerAbility(); // Try to give the player a new skill from his enemy (Does have the chance to fail)
                State = BattleState.Victory;
            }
            else
            {
                if (State == BattleState.PlayerTurn) 
                {
                    State = BattleState.EnemyTurn;
                }
                else if (State == BattleState.EnemyTurn)
                {
                    EnemyAttack();
                    State = BattleState.PlayerTurn;
                }
            }
        }
    }
}
