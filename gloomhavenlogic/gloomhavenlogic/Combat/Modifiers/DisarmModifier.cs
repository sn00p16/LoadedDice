using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class DisarmModifier : AttackModifier
    {
        public DisarmModifier() : base(AttackModifierType.Disarm, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
