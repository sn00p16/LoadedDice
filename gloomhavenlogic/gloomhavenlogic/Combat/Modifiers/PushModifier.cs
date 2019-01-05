using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class PushModifier : AttackModifier
    {
        public PushModifier() : base() { }
        public PushModifier(int steps) : base(AttackModifierType.Push, steps) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
