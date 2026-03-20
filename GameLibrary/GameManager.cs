using Core.State;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Core
{
    public class GameManager
    {
        private Object CurrentWindow { get; set; } // IM SURE I CAN BE MORE SPECIFIC
        private GameState CurrentState { get; set; }
        private Fighter CurrentPlayer { get; set; }
        private BattleManager CurrentBattleManager { get; set; }
        private ShopManager CurrentShopManager { get; set; }
        private void OnGameOver()
        {

        }
        private void OnBattleOver()
        {

        }
        private void OnShopOver()
        {

        }
        private void OnGameStart()
        {

        }
        
    }
}
