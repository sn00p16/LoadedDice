using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class ElementModifier : AttackModifier
    {
        public ElementModifier() : base() { }
        public ElementModifier(Element element) : base(AttackModifierType.Element, (int)element) { }

        public override void ApplyModifier()
        {
            base.ApplyModifier();
        }
    }
}
