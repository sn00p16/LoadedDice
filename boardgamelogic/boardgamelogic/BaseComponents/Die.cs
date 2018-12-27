using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boardgamelogic.BaseComponents
{
    public class Side
    {
        #region Constructors

        public Side() { }

        #endregion

        #region Fields

        public int Value { get { return GetValue(); } }

        #endregion

        #region Public Methods

        protected virtual int GetValue() { return 0; }

        #endregion
    }

    public class Die
    {
        #region Constructors

        public Die()
        {
            Side = null;
            RNG = new System.Random();
            Sides = new List<Side>();
        }

        public Die(int sides) : this()
        {
            GenerateDefaultSides(sides);
        }

        public Die(List<Side> sides) : this()
        {
            Sides.AddRange(sides);
        }

        #endregion

        #region Fields

        public int Value { get { return (Side != null) ? Side.Value : 0; } }
        public Side Side { get; protected set; }

        #endregion

        #region Members

        protected List<Side> Sides { get; set; }
        protected System.Random RNG { get; set; }

        #endregion

        #region Public Methods

        public virtual void Roll()
        {
            if (Sides.Count == 0)
                return;

            var index = RNG.Next(Sides.Count);
            Side = Sides[index];
        }

        #endregion

        #region Protected Methods

        protected virtual void GenerateDefaultSides(int sides)
        {
            if (sides <= 0)
            {
                Side = null;
                return;
            }

            Sides.Clear();
            while (Sides.Count < sides)
                Sides.Add(new Side());
        }

        #endregion
    }
}
