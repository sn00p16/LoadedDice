using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class ImmobilizeModifier : AttackModifier
    {
        public ImmobilizeModifier() : base(AttackModifierType.Immobilize, 0) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
