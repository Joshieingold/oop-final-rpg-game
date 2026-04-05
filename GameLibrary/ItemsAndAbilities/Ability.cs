using Core.Entities;
using Core.ItemsAndAbilities;

namespace Core.Items
{
    public abstract class Ability : IAbility
    {
        /////////////////
        // Constructor //
        /////////////////
        public Ability()
        {
            Sprite =  "ShopItems/PlaceHolder.png"; // DO I EVEN NEED TO SAY IT?
        }
        ////////////
        // Fields //
        ////////////
        private string _name;
        private int _price;
        private int _manaCost;

        ////////////////
        // Properties //
        ////////////////
        public string Sprite { get; set; }
        public int ManaCost // Cannot be less than 1.
        {
            get { return _manaCost; }
            set
            {
                if (value < 1) _manaCost = 1;
                else _manaCost = value;
            }
        }
        public string Name // Name cannot be set to none
        {
            get { return _name; }
            set
            {
                if (value == "") _name = "UnknownSkll";
                else _name = value;
                Sprite = DetermineSprite(_name);
            }
        }
        public int Price // cannot cost less than 1.
        {
            get { return _price; }
            set
            {
                if (value < 1) _price = 1;
                else _price = value;
            }
        }

        //////////////////////////
        // Methods To Implement //
        //////////////////////////
        public abstract void Use(Fighter attacker, Fighter defender); // how a player handles using an ability.
        public virtual void Buy(Fighter player) // How a player handles buying an ability.
        {
            player.Abilities.Add(this); //default is just to gain access to it.
        }
        public int GetManaCost() // Required because of IAbility..
        {
            return ManaCost;
        }
        private string DetermineSprite(string key) // Sets the sprite based on name of item.
        {
            var AbilityNames = new Dictionary<string, string>
            {
                {"Vim", "ShopItems/vim.png"  },
                {"Breakpoints", "ShopItems/breakpoint.png"  },
                {"For Loop", "ShopItems/forLoop.png"  },
                {"Vs Code", "ShopItems/vsCode.png"  },
                {"Code Completion", "ShopItems/codeCompletion.png"  },
                {"Database Power", "ShopItems/database.png"  },
            };
            if (AbilityNames.TryGetValue(key, out string sprite))
            {
                return sprite;
            }
            else
            {
                return "ShopItems/PlaceHolder.png";
            }
        }
    }
}
