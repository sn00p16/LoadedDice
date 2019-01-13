using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class MuddleModifier : AttackModifier
    {
        public MuddleModifier() : base(AttackModifierType.Muddle, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
