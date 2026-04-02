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
        public List<Enemy> AllEnemies { get; set; }
        public BattleManager CurrentBattleManager { get; set; }
        public ShopManager CurrentShopManager { get; set; }
        public int Round { get; set; }

        public GameManager(string playerName, bool gender)
        {
            CurrentPlayer = new Player(playerName, gender);
            CurrentState = GameState.Shop;
            Round = 1;
            CurrentShopManager = new ShopManager();
            AllEnemies = new EnemyFactory().RequestXNewEnemies(GAME_ROUNDS);
            AllEnemies.Sort(); // Sorted for difficulty
        }
        public Enemy GetCurrentEnemy()
        {
            return AllEnemies[Round - 1];
        }
        public void UpdateState(GameState newState)
        {
            if (newState == GameState.Battle)
            {
                CurrentState = GameState.Battle;
                CurrentBattleManager = new BattleManager(CurrentPlayer, GetCurrentEnemy());
            }
            else if (newState == GameState.Shop)
            {
                CurrentState = GameState.Shop;
                CurrentShopManager = new ShopManager();
            }
            else if (newState == GameState.Victory)
            {
                CurrentState = GameState.Victory;
                UploadGame();

            }
            else if (newState == GameState.Defeat)
            {
                CurrentState = GameState.Defeat;
                UploadGame();
            }
        }
        private void UploadGame()
        {
            string newRecord = $"{CurrentState} | {CurrentPlayer.Name} | {DateTime.Now} | Round {Round} " + Environment.NewLine;
            string path = DataPasser.GeneralLocation() + "GameRecord.txt";
            File.AppendAllText(path, newRecord);
        }
        public void OnShopOver(Player updatedPlayer)
        {
            CurrentPlayer = updatedPlayer;
            Round++;
            CurrentShopManager = new ShopManager();
        }
        
    }
}
