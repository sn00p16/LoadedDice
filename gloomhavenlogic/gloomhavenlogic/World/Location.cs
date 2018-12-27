using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.World
{
    public class Location
    {
        #region Constructors

        public Location() { state = LocationState.Undefined; }

        #endregion

        #region Public Fields

        public int Number { get; protected set; }
        public LocationState State { get { return GetState(); } }

        #endregion

        #region Protected Fields

        protected LocationState state;

        #endregion

        #region Public Methods

        public void Reveal()
        {
            state = LocationState.Revealed;
        }

        public void Complete()
        {
            state = LocationState.Completed;
        }

        #endregion

        #region Protected Methods

        protected LocationState GetState()
        {
            return state;
        }

        #endregion
    }
}
