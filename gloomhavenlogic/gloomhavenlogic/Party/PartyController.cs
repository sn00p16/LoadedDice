using gloomhavenlogic.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Party
{
    public sealed class PartyController
    {
        #region Constructors

        public PartyController()
        {
            Name = "";
            Reputation = 0;

            Characters = new List<Character>();
            Achievements = new Dictionary<PartyAchievement, bool>();
            for(var i = PartyAchievement.Undefined + 1; i < PartyAchievement.Max; ++i)
                Achievements[i] = false;

        }

        #endregion

        #region Constants

        private const int MaxReputation = 20;

        #endregion

        #region Public Fields

        public string Name { get; private set; }
        public List<Character> Characters { get; private set; }
        
        public Dictionary<PartyAchievement, bool> Achievements { get; private set; }

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
                int min = int.MaxValue;
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

        #region Public Methods

        public void AddReputation(int value)
        {
            Reputation += value;

            // Bounds limit
            if (Reputation > MaxReputation)
                Reputation = MaxReputation;
            else if (Reputation < -MaxReputation)
                Reputation = -MaxReputation;
        }

        public void AddAchievement(PartyAchievement achievement)
        {
            if (achievement != PartyAchievement.Undefined)
                Achievements[achievement] = true;
        }

        public void RemoveAchievement(PartyAchievement achievement)
        {
            if (achievement != PartyAchievement.Undefined)
                Achievements[achievement] = false;
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
