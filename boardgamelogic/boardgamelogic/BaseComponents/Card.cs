using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boardgamelogic.BaseComponents
{
    public class Card
    {
        #region Constructors

        public Card()
        {
            IsFaceDown = false;
            IsTapped = false;
            CardIndex = 0;
        }

        public Card(int index) : this()
        {
            CardIndex = index;
        }

        #endregion

        #region Fields

        public bool IsFaceDown { get; protected set; }
        public bool IsTapped { get; protected set; }
        public int SortingIndex { get { return GetSortingIndex(); } }

        #endregion

        #region Public Methods

        public virtual void Flip()
        {
            IsFaceDown = !IsFaceDown;
        }
        public virtual void Tap()
        {
            IsTapped = true;
        }
        public virtual void UnTap()
        {
            IsTapped = false;
        }

        #endregion

        #region Protected Members

        protected int CardIndex { get; set; }

        #endregion

        #region Protected Methods

        protected virtual int GetSortingIndex()
        {
            return CardIndex;
        }

        #endregion
    }
}
