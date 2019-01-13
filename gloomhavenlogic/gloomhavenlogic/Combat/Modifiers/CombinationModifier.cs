using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class CombinationModifier : AttackModifier
    {
        public CombinationModifier() : base()
        {
            Modifiers = new List<AttackModifier>();
        }
        public CombinationModifier(List<AttackModifier> modifiers) : base(AttackModifierType.Combination, 0)
        {
            Modifiers.AddRange(modifiers);
        }

        public List<AttackModifier> Modifiers { get; protected set; }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
