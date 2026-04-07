using Core.ItemsAndAbilities;
using Core.Factories;

namespace Core.Entities
{
    public sealed class Player : Fighter
    {
        /////////////////
        // Constructor //
        /////////////////
        public Player(string inName) // Creates a player with a name passed in.
        {
            Money = 5;
            Name = inName;
            IsMale = true;
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }
        public Player(string inName, bool inIsMale) // Creates a player with a name passed in and their gender for the sprite.
        {
            Money = 5;
            Name = inName;
            IsMale = inIsMale;
            Abilities = new List<IAbility>();
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }

        ////////////
        // Fields //
        ////////////
        private bool _isMale;
        private string _name;
        private int _money;

        ////////////////
        // Properties //
        ////////////////
        public int Money // Money cannot be below 0.
        {
            get { return _money; }
            set
            {
                if (value < 0)
                {
                    _money = 0;
                }
                else
                {
                    _money = value;
                }
            }
        }
        public string PlayerSprite { get; private set; } // this is determined by their gender
        public new string Name // Name of the player. has its own logic
        {
            get { return _name; }
            set
            {
                if (value == "")
                {
                    throw new InvalidDataException(); // Throws if you try to pass in an invalid name.
                }
                else
                {
                    _name = value;
                }
            }
        }
        public bool IsMale // Sets the sprite for the player based on this.
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

        /////////////
        // Methods //
        /////////////
        public bool CheckCanAfford(int cost) // Checks to see if the user can buy an item (Used by UI so unfortuately public.)
        {
            if (Money - cost >= 0)
            {
                return true;
            }
            return false;
        }
        public void TryBuy(IShopItem item) // Gives the item to the user if they can afford it.
        {
            if (!CheckCanAfford(item.Price)) return;
            item.Buy(this);
            Money -= item.Price;
        }
    }
}
