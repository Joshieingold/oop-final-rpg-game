using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class ShopManager
    {
        public ShopManager(Fighter inPlayer)
        {
            currentPlayer = inPlayer;
        }
        private Fighter currentPlayer { get; set; }
        private int _rollNumber = 0;
        public int RollNumber
        {
            get { return _rollNumber; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                _rollNumber = value;
            }
        }
        public List<IShopItem> AvailableItems { get; set; }
        public void Roll()
        {
            return;
        }
        public void Exit()
        {
            return;
        }
    }
}
