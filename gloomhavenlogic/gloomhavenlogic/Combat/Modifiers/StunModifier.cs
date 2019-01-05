using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class StunModifier : AttackModifier
    {
        public StunModifier() : base(AttackModifierType.Stun, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
