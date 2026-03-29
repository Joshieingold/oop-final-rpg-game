using Core.Entities;
using Core.State;
using Core.Factories;
using GameData;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Core.Managers
{
    public class GameManager
    {
        public const int GAME_ROUNDS = 8;
        public GameState CurrentState { get; private set; }
        public Player CurrentPlayer { get; set; }
        public List<Enemy> AllEnemies = new EnemyFactory().RequestXNewEnemies(GAME_ROUNDS);
        public BattleManager CurrentBattleManager { get; set; }
        public ShopManager CurrentShopManager { get; set; }
        public int Round { get; set; }

        public GameManager(string playerName, bool gender)
        {
            CurrentPlayer = new Player(playerName, gender);
            CurrentState = GameState.Shop;
            Round = 1;
            CurrentShopManager = new ShopManager();
        }
        // This doesnt need to be like that can jsut be a get set.
        public Enemy GetCurrentEnemy()
        {
            return AllEnemies[Round - 1];
        }
        public void UpdateState(GameState newState)
        {
            switch (newState)
            {
                case GameState.Battle:
                    CurrentState = GameState.Battle;
                    CurrentBattleManager = new BattleManager(CurrentPlayer, GetCurrentEnemy());
                    break;
                case GameState.Shop:
                    CurrentState = GameState.Shop;
                    CurrentShopManager = new ShopManager();
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
        public void OnShopOver(Player updatedPlayer)
        {
            CurrentPlayer = updatedPlayer;
            Round++;
            CurrentShopManager = new ShopManager();
        }
        private void OnGameStart()
        {

        }
        
    }
}
