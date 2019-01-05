using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class DamageAdjustModifier : AttackModifier
    {
        public DamageAdjustModifier() : base() { }
        public DamageAdjustModifier(int modifier) : base(AttackModifierType.DamageAdjust, modifier) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
