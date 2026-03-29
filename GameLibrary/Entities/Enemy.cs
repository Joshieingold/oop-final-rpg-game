using Core.ItemsAndAbilities;
using Core.Factories;
using Core.State;
using GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Enemy : Fighter
    {
        private int _maxMoves;
        private ProgLang _errorType;

        // Max moves creates a new list of abilities of that length
        public int MaxMoves
        {
            get { return _maxMoves; }
            set
            {
                Abilities = new AbilityFactory().GetXNewAbilities(value);
                _maxMoves = value;
            }
        }

        // Sets the enemies Sprite based on Programming language of enemy
        public ProgLang ErrorType
        {
            get { return _errorType; }
            set
            {
                EnemySprite = DetermineImage(value);
                _errorType = value;
            }

        }

        // Stores the path to the particular sprites image
        public string EnemySprite { get; private set; } // this is determined by their prog lang
        public List<IAbility> Abilities { get; set; }

        public Enemy()
        {
            Abilities = new AbilityFactory().GetXNewAbilities(4);
        }

        // Selects a random ability from available Abilities
        public IAbility ChooseRandomAbility()
        {
            Random rand = new Random();
            int choiceIndex = rand.Next(Abilities.Count);
            return Abilities[choiceIndex];
        }
        // returns path based on a proglang
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
