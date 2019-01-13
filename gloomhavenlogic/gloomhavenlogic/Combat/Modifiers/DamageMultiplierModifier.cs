using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class DamageMultiplierModifier : AttackModifier
    {
        public DamageMultiplierModifier() : base() { }
        public DamageMultiplierModifier(int multiplier) : base(AttackModifierType.DamageMultiplier, multiplier) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
