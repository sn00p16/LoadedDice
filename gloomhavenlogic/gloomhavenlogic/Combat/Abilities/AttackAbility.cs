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
        public AttackAbility(int value) : base(Ability.Attack, value)
        {
            Range = 0;
            Ranged = false;
        }
        public AttackAbility(int value, int range) : this(value)
        {
            Range = range;
            Ranged = true;
        }

        public int Range { get; protected set; }
        public bool Ranged { get; protected set; }
    }
}
