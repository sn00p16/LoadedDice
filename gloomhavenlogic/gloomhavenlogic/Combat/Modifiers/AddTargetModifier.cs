using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class AddTargetModifier : AttackModifier
    {
        public AddTargetModifier() : base() { }
        public AddTargetModifier(int targets) : base(AttackModifierType.AddTarget, targets) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
