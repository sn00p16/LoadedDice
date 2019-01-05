using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public class AttackModifier
    {
        public AttackModifier()
        {
            Type = AttackModifierType.Undefined;
        }
        public AttackModifier(AttackModifierType type, int value)
        {
            Type = type;
            Value = value;
        }

        public AttackModifierType Type { get; protected set; }
        public int Value { get; protected set; }

        public virtual void ApplyModifier()
        {
            // Do something "tons of fun"
        }
    }
}
