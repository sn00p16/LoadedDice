using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.World
{
    public sealed class GlobalController
    {
        #region Constructors

        public GlobalController()
        {
            Achievements = new Dictionary<GlobalAchievement, bool>();
            for (var i = GlobalAchievement.Undefined + 1; i < GlobalAchievement.Max; ++i)
                Achievements[i] = false;
            Locations = new List<Location>();

            ProsperityPoints = 0;
            AncientTechnologyLevel = 0;
        }

        #endregion

        #region Public Fields

        public int ProsperityLevel { get { return GetProsperityLevel(); } }
        public List<Location> GetAvailableLocations { get { return Locations.FindAll(l => l.State == LocationState.Revealed); } }
        public Dictionary<GlobalAchievement, bool> Achievements { get; private set; }
        public int AncientTechnologyLevel { get; private set; }

        #endregion

        #region Private Fields

        private List<Location> Locations { get; set; }
        private int ProsperityPoints { get; set; }

        #endregion

        #region Public Methods

        public void AddProsperity(int prosperity)
        {
            ProsperityPoints += prosperity;
            if (ProsperityPoints < 0) ProsperityPoints = 0;
        }

        public void RevealLocations(List<int> locations)
        {
            foreach (var number in locations)
                RevealLocation(number);
        }

        public void RevealLocation(int number)
        {
            foreach (var location in Locations)
            {
                if (location.Number == number)
                    location.Reveal();
            }
        }

        public void AddAchievement(GlobalAchievement achievement)
        {
            if (achievement == GlobalAchievement.Undefined)
                return;

            Achievements[achievement] = true;
        }

        public void RemoveAchievement(GlobalAchievement achievement)
        {
            if (achievement == GlobalAchievement.Undefined)
                return;

            Achievements[achievement] = false;
        }

        #endregion

        #region Protected Methods

        private int GetProsperityLevel()
        {
            // Calculate the level based on thresholds
            return 1;
        }

        #endregion

        #region Singleton Implementation

        private static GlobalController instance = null;
        private static readonly object padlock = new object();

        public static GlobalController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalController();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
