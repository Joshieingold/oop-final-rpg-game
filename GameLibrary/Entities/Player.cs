using Core.ItemsAndAbilities;
using Core.Factories;

namespace Core.Entities
{
    public sealed class Player : Fighter
    {
        private bool _isMale;
        private string _name;
        public int Money { get; set; }
        public string PlayerSprite { get; private set; } // this is determined by their gender
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == "")
                {
                    throw new InvalidDataException();
                }
                else
                {
                    _name = value;
                }
            }

        }
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
        public void TryBuy(IShopItem item)
        {
            if (!CheckCanAfford(item.Price))
            {
                return;
            }
            item.Buy(this);
            Money -= item.Price;
        }
    }
}
