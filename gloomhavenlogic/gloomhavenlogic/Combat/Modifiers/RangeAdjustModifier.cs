using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class RangeAdjustModifier : AttackModifier
    {
        public RangeAdjustModifier() : base() { }
        public RangeAdjustModifier(int modifier) : base(AttackModifierType.RangeAdjust, modifier) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
