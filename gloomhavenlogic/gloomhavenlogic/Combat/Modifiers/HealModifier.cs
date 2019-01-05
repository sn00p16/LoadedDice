using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class HealModifier : AttackModifier
    {
        public HealModifier() : base() { }
        public HealModifier(int points) : base(AttackModifierType.Heal, points) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
