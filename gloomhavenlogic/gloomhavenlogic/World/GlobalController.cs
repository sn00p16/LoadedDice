using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.World
{
    public sealed class GlobalController
    {
        #region Constructors

        public GlobalController() { }

        #endregion

        #region Public Fields

        public int ProsperityLevel { get; private set; }
        public List<GlobalAchievement> Achievements { get; private set; }
        public List<Location> GetAvailableLocations { get { return Locations.FindAll(l => l.State == LocationState.Revealed); } }

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

            RefreshProsperityLevel();
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

        #endregion

        #region Protected Methods

        private void RefreshProsperityLevel()
        {
            // Calculate the level based on thresholds
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
