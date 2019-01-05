using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class WoundModifier : AttackModifier
    {
        public WoundModifier() : base(AttackModifierType.Wound, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
