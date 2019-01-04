using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Abilities
{
    public class AttackAbility : BaseAbility
    {
        public AttackAbility() : base()
        {
            Range = 0;
            Ranged = false;
        }
        public AttackAbility(int value, List<BaseAbility> subabilities = null, List<Element> cost = null) : base(Ability.Attack, value, subabilities, cost)
        {
            Range = 0;
            Ranged = false;
        }
        public AttackAbility(int value, int range, List<BaseAbility> subabilities = null, List<Element> cost = null) : this(value)
        {
            Range = range;
            Ranged = true;
        }

        public int Range { get; protected set; }
        public bool Ranged { get; protected set; }
    }
}
