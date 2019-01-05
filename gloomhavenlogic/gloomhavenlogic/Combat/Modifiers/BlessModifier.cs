using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class BlessModifier : AttackModifier
    {
        public BlessModifier() : base() { }
        public BlessModifier(int blessings) : base(AttackModifierType.Bless, blessings) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
