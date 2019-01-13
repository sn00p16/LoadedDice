using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class Strengthen : AttackModifier
    {
        public Strengthen() : base(AttackModifierType.Strengthen, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
