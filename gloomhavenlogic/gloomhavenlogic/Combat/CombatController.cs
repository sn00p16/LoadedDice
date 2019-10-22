using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public sealed class CombatController
    {
        public CombatController() { }

        public void DoCombat(string attacker, string defenders)
        {
            // Get base attack value (range is assumed to be good)
            // Apply item modifier(s)
            // Apply round attack modifier(s)
            // Apply buff attack modifier(s)
            // Apply attack adjust modifier(s) from modifier cards
            // Apply attack multiplier modifier(s) from modifier cards

            // Get base defense value
            // Apply item modifier(s)
            // Apply round defense modifier(s)
            // Apply buff defense modifier(s)
            
            // Subtract defense from attack
            // Apply damage dependent defense modifier(s)
            // Apply damage

            // Apply conditions
        }

        #region Singleton Implementation

        private static CombatController instance = null;
        private static readonly object padlock = new object();

        public static CombatController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new CombatController();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
