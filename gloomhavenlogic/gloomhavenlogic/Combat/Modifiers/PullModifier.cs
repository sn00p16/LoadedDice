using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class PullModifier : AttackModifier
    {
        public PullModifier() : base() { }
        public PullModifier(int steps) : base(AttackModifierType.Pull, steps) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
