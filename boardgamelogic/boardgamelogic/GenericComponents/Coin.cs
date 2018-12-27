using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using boardgamelogic.Defines;

namespace boardgamelogic.GenericComponents
{
    public class Coin : StandardDie
    {
        #region Constructors

        public Coin() : base(2)
        {
            Face = CoinFace.Undefined;
        }

        #endregion

        #region Fields

        public CoinFace Face { get; protected set; }

        #endregion

        #region Public Methods

        public virtual void Flip()
        {
            Roll();
            Face = (CoinFace)Value;
        }

        #endregion
    }
}
