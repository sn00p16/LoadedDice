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
        public HealAbility(int value, List<BaseAbility> subabilities = null, List<Element> cost = null) : base(Ability.Heal, value, subabilities, cost)
        {
            Range = 0;
            Self = false;
        }
        public HealAbility(int value, bool self, List<BaseAbility> subabilities = null, List<Element> cost = null) : this(value)
        {
            Range = 0;
            Self = self;
        }
        public HealAbility(int value, int range, List<BaseAbility> subabilities = null, List<Element> cost = null) : this(value)
        {
            Range = range;
            Self = false;
        }

        public int Range { get; protected set; }
        public bool Self { get; protected set; }
    }
}
