using Core.ItemsAndAbilities;
using Core.Factories;
using Core.State;

namespace Core.Entities
{
    public class Enemy : Fighter, IComparable<Enemy>
    {
        ///////////////
        // Constants //
        ///////////////
        private const int DEFAULT_MAX_MOVES = 4;

        /////////////////
        // Constructor //
        /////////////////
        public Enemy()
        {
            MaxMoves = DEFAULT_MAX_MOVES; // Sets abilities list as well.
        }

        ////////////
        // Fields //
        ////////////
        private ProgLang _errorType;
        private int _maxMoves;

        ////////////////
        // Properties //
        ////////////////
        public string EnemySprite { get; private set; } // Determined only by ProgLang.
        public int MaxMoves // Determines the amount of abilities an enemy has.
        {
            get { return _maxMoves; }
            set
            {
                // Enemies Abilities are automatically set to be random x amount of abilities.
                Abilities = new AbilityFactory().GetXNewAbilities(value);
                _maxMoves = value;
            }
        }
        public ProgLang ErrorType // Associtated Programming Language of the enemy
        {
            get { return _errorType; }
            set
            {
                // EnemySprite is set based on their ProgLang.
                EnemySprite = DetermineImage(value);
                _errorType = value;
            }
        }

        /////////////
        // Methods //
        /////////////
        public int CompareTo(Enemy other) // Implementing IComparable for Lists of Enemies
        {
            // Comparison is done by adding together stats for the monster and averaging it compared to the next.
            if (other == null) return 1;
            int thisCmp = (this.Attack + this.Defense + this.Health) / 3;
            int otherCmp = (other.Attack + other.Defense + other.Health) / 3;
            return thisCmp.CompareTo(otherCmp);
        }

        public IAbility ChooseRandomAbility() // Selects a random ability from Enemies available Abilities
        {
            Random rand = new Random();
            int choiceIndex = rand.Next(Abilities.Count);
            return Abilities[choiceIndex];
        }

        private string DetermineImage(ProgLang lang) // returns sprite path based on a proglang
        {
            switch(lang)
            {
                case ProgLang.Javascript:
                    return "/CreatureArt/scriptbeard.png";
                case ProgLang.Cs:
                    return "/CreatureArt/princesharp.png";
                case ProgLang.C:
                    return "/CreatureArt/pluscritters.png";
                case ProgLang.Java:
                    return "/CreatureArt/javacup.png";
                case ProgLang.Cpp:
                    return "/CreatureArt/pluscritters.png";
                case ProgLang.Python:
                    return "/CreatureArt/systemsnakes.png";
                case ProgLang.Bash:
                    return "/CreatureArt/basher.png";
                default:
                    throw new NotImplementedException(); // Throws if image cannot be determined.
            }
        }
    }
}
