using gloomhavenlogic.Class;
using gloomhavenlogic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Party
{
    public class Character
    {
        #region Constructors

        public Character() { }

        #endregion

        #region Public Fields

        public string Name { get; protected set; }
        public Race Race { get; protected set; }
        public PlayerClassType Class { get; protected set; }

        public int Gold { get; protected set; }
        public int Experience { get; protected set; }
        public int Level { get { return GetLevel(); } }
        public int Checks { get; protected set; }

        #endregion

        #region Protected Methods

        protected int GetLevel()
        {
            return Experience;
        }

        #endregion
    }
}
