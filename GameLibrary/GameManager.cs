using Core.State;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Core
{
    public class GameManager
    {
        public GameState CurrentState { get; private set; }
        public Player CurrentPlayer { get; set; }
        public BattleManager CurrentBattleManager { get; set; }
        public ShopManager CurrentShopManager { get; set; }
        public int Round { get; set; }

        public GameManager(string playerName, bool gender)
        {
            CurrentPlayer = new Player(playerName, gender);
            CurrentState = GameState.Shop;
            Round = 1;
            CurrentShopManager = new ShopManager(CurrentPlayer);
        }
        // This doesnt need to be like that can jsut be a get set.
        public void UpdateState(GameState newState)
        {
            switch (newState)
            {
                case GameState.Battle:
                    CurrentState = GameState.Battle;
                    CurrentBattleManager = new BattleManager(CurrentPlayer);
                    break;
                case GameState.Shop:
                    CurrentState = GameState.Shop;
                    CurrentShopManager = new ShopManager(CurrentPlayer);
                    break;
                    // Oviously we need the defeat and victory case some day
            }

        }
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
