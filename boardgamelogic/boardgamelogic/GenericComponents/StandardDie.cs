using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using boardgamelogic.BaseComponents;

namespace boardgamelogic.GenericComponents
{
    public class StandardSide : Side
    {
        #region Constructors

        public StandardSide() : base()
        {
            Pips = 0;
        }

        public StandardSide(int value) : this()
        {
            Pips = value;
        }

        #endregion

        #region Members

        protected int Pips { get; set; }

        #endregion

        #region Protected Methods

        protected override int GetValue() { return Pips; }

        #endregion
    }

    public class StandardDie : Die
    {
        #region Constructors

        public StandardDie() : base() { }

        public StandardDie(int sides) : base(sides) { }

        #endregion

        #region Protected Methods

        protected override void GenerateDefaultSides(int sides)
        {
            if (sides <= 0)
                return;

            Sides.Clear();
            while (Sides.Count < sides)
                Sides.Add(new StandardSide(Sides.Count + 1));
        }

        #endregion
    }

    public class d4 : StandardDie { public d4() : base(4) { } }
    public class d6 : StandardDie { public d6() : base(6) { } }
    public class d8 : StandardDie { public d8() : base(8) { } }
    public class d10 : StandardDie { public d10() : base(10) { } }
    public class d12 : StandardDie { public d12() : base(12) { } }
    public class d20 : StandardDie { public d20() : base(20) { } }
}
