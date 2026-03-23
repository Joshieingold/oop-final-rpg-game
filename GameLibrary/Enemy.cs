using Core.State;
using GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Enemy : Fighter
    {
        private int _maxMoves;
        public int MaxMoves
        {
            get { return _maxMoves; }
            set
            {
                Abilities = new AbilityFactory().GetXNewAbilities(value);
                _maxMoves = value;
            }
        }
        public string EnemySprite { get; private set; } // this is determined by their prog lang
        private ProgLang _errorType;
        public List<IAbility> Abilities { get; set; }
        public Enemy()
        {
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }
        public ProgLang ErrorType
        {
            get { return _errorType; }
            set
            {
                EnemySprite = DetermineImage(value);
                _errorType = value;
            }

        }
        private string DetermineImage(ProgLang lang)
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
                    Console.WriteLine("Error: Image location not set");
                    return "Generic";
            }
        }
    }
}
