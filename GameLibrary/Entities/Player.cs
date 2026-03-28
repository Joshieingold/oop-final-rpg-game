using Core.ItemsAndAbilities;
using Core.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public sealed class Player : Fighter
    {
        public int Money { get; set; }
        private bool _isMale;
        public string PlayerSprite { get; private set; } // this is determined by their gender
        public bool IsMale
        {
            get { return _isMale; }
            set
            {
                if (value == true)
                {
                    PlayerSprite = "/ProtagonistSprites/nanon.png";
                }
                else
                {
                    PlayerSprite = "/ProtagonistSprites/vimmi.png";
                }
                _isMale = value;
            }

        }
        public Player(string inName)
        {
            Money = 5;
            Name = inName;
            IsMale = true;
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }
        public Player(string inName, bool inIsMale)
        {
            Money = 5;
            Name = inName;
            IsMale = inIsMale;
            Abilities = new List<IAbility>();
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }
        public bool CheckCanAfford(int cost)
        {
            if (Money - cost >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
