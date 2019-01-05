using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class PoisonModifier : AttackModifier
    {
        public PoisonModifier() : base(AttackModifierType.Poison, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
