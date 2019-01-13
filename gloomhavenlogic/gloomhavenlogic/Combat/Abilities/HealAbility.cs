using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Abilities
{
    public class HealAbility : BaseAbility
    {
        public HealAbility() : base()
        {
            Range = 0;
            Self = false;
        }
        public HealAbility(int value) : base(Ability.Heal, value)
        {
            Range = 0;
            Self = false;
        }
        public HealAbility(int value, bool self) : this(value)
        {
            Range = 0;
            Self = self;
        }
        public HealAbility(int value, int range) : this(value)
        {
            Range = range;
            Self = false;
        }

        public int Range { get; protected set; }
        public bool Self { get; protected set; }
    }
}
