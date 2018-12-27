using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using boardgamelogic.Defines;

namespace boardgamelogic.BaseComponents
{
    public class Token
    {
        #region Constructors

        public Token()
        {
            RotationIndex = 0;
            Rotations = 0;
            IsFaceDown = false;
        }

        public Token(bool facedown) : this()
        {
            IsFaceDown = facedown;
        }

        public Token(int rotations) : this()
        {
            Rotations = rotations;
        }

        public Token(int rotations, bool facedown) : this(rotations)
        {
            IsFaceDown = facedown;
        }

        #endregion

        #region Fields

        public int Rotations { get; protected set; }
        public int RotationIndex { get; protected set; }
        public bool IsFaceDown { get; protected set; }

        #endregion

        #region Public Methods

        public virtual void Flip()
        {
            IsFaceDown = !IsFaceDown;

            OnFlip();
        }

        public virtual void Rotate(RotationDirection direction, int steps)
        {
            if (direction == RotationDirection.Anticlockwise)
                steps *= -1;

            RotationIndex = (RotationIndex + steps) % Rotations;
            if (RotationIndex < 0)
                RotationIndex += Rotations;
        }

        public virtual double GetRotation()
        {
            if (Rotations == 0)
                return 0.0;

            double rotationRatio = RotationIndex / Rotations;
            return 360.0 * rotationRatio;
        }

        #endregion

        #region Protected Methods

        protected virtual void OnFlip() { }

        #endregion
    }
}
