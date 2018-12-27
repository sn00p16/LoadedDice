using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Class
{
    public class ClassController
    {
        #region Constructors

        public ClassController() { }

        #endregion

        #region Public Fields

        public List<PlayerClass> Classes { get; protected set; }
        public List<PlayerClass> UnlockedClasses { get { return Classes.FindAll(c => c.State != PlayerClassState.Locked); } }
        public List<PlayerClass> AvailableClasses { get { return Classes.FindAll(c => c.State == PlayerClassState.Unlocked); } }
        public List<PlayerClass> PlayedClasses { get { return Classes.FindAll(c => c.State == PlayerClassState.InPlay); } }

        #endregion
    }
}
