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
        public BattleManager(Player inPlayer)
        {
            CurrentPlayer = inPlayer;
            CurrentState = BattleState.PlayerTurn;
        }
        private void UpdateState()
        {
            return;
        }
    }
}
