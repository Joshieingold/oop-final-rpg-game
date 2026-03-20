using Core.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BattleManager
    {
        private Fighter CurrentPlayer { get; set; }
        public Fighter CurrentEnemy { get; set; }
        private Fight CurrentFight { get; set; }
        private BattleState CurrentState { get; set; }
        private void UpdateState()
        {
            return;
        }
    }
}
