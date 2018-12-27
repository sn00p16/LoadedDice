using gloomhavenlogic.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Party
{
    public sealed class PartyController
    {
        #region Constructors

        public PartyController() { }

        #endregion

        #region Public Fields

        public string Name { get; private set; }
        public List<Character> Characters { get; private set; }

        public List<string> Achievements { get; private set; }

        public int Reputation { get; private set; }
        public int Level { get { return GetPartyLevel(); } }

        public int GoldCollective
        {
            get
            {
                int total = 0;
                foreach (var character in Characters)
                    total += character.Gold;

                return total;
            }
        }

        public int GoldMinimum
        {
            get
            {
                int min = 999999999;
                foreach (var character in Characters)
                    if (character.Gold < min)
                        min = character.Gold;

                return min;
            }
        }

        public List<PlayerClassType> Classes
        {
            get
            {
                var list = new List<PlayerClassType>();
                foreach (var character in Characters)
                    list.Add(character.Class);

                return list;
            }
        }

        #endregion

        #region Private Methods

        private int GetPartyLevel()
        {
            int total = 0;
            foreach(var player in Characters)
                total += player.Level;

            return total / Characters.Count;
        }

        #endregion

        #region Singleton Implementation

        private static PartyController instance = null;
        private static readonly object padlock = new object();

        public static PartyController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PartyController();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
