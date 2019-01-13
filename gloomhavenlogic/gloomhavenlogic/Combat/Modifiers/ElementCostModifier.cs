using gloomhavenlogic.Scenario;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Modifiers
{
    public class ElementCostModifier : AttackModifier
    {
        public ElementCostModifier() : base()
        {
            Elements = new List<Element>();
            PassThroughModifier = null;
        }
        public ElementCostModifier(List<Element> elements, AttackModifier modifier) : base(AttackModifierType.ElementCost, elements.Count)
        {
            Elements.AddRange(elements);
            PassThroughModifier = modifier;
        }

        public List<Element> Elements { get; protected set; }
        public AttackModifier PassThroughModifier { get; protected set; }

        public override void ApplyModifier()
        {
            if (CanApply())
                PassThroughModifier.ApplyModifier();
        }

        public override bool CanApply()
        {
            // Check for elements
            foreach(var element in Elements)
            {
                if (ElementBoard.Instance.IsElementInert(element))
                    return false;
            }

            return PassThroughModifier.CanApply();
        }
    }
}
