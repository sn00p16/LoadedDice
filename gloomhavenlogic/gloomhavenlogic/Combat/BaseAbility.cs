using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public class BaseAbility
    {
        public BaseAbility()
        {
            Type = Ability.Undefined;
            Value = 0;

            ElementalCost = new List<Element>();
            SubAbilities = new List<BaseAbility>();
        }
        public BaseAbility(Ability type, int value) : this()
        {
            Type = type;
            Value = value;
        }
        public BaseAbility(Ability type, int value, List<BaseAbility> subabilities, List<Element> cost = null) : this(type, value)
        {
            if (subabilities != null && subabilities.Count > 0)
                SubAbilities.AddRange(subabilities);
            if (cost != null && cost.Count > 0)
                ElementalCost.AddRange(cost);
        }

        public Ability Type { get; protected set; }
        public int Value { get; protected set; }

        public List<Element> ElementalCost { get; protected set; }
        public List<BaseAbility> SubAbilities { get; protected set; }

        public virtual void Perform()
        {
            // Perform the action, override this
        }

        public virtual bool CanPerform()
        {
            // Can we perform the action? Override this
            return true;
        }
    }
}
