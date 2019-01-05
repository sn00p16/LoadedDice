using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class ShieldModifier : AttackModifier
    {
        public ShieldModifier() : base() { }
        public ShieldModifier(int shields) : base(AttackModifierType.Shield, shields) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
