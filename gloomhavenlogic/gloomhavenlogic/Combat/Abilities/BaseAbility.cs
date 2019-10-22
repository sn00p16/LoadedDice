using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Abilities
{
    public class BaseAbility
    {
        public BaseAbility()
        {
            Type = Ability.Undefined;
            Value = 0;
        }
        public BaseAbility(Ability type, int value) : this()
        {
            Type = type;
            Value = value;
        }

        public Ability Type { get; protected set; }
        public int Value { get; protected set; }

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
