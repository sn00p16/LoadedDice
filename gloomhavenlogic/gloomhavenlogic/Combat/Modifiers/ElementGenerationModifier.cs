using gloomhavenlogic.Scenario;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class ElementGenerationModifier : AttackModifier
    {
        public ElementGenerationModifier() : base() { }
        public ElementGenerationModifier(Element element) : base(AttackModifierType.ElementGeneration, (int)element) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
