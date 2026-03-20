using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Fight
    {
        private Fighter attacker { get; set; }
        private Fighter defender { get; set; }
        public List<Fighter> OnFinsh()
        {
            StartFight();
            return new List<Fighter>() { attacker,defender};
        }
        private void StartFight()
        {
            return;
        }
    }
}
