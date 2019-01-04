using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat.Abilities
{
    public class MoveAbility : BaseAbility
    {
        public MoveAbility() : base()
        {
            Jump = false;
        }
        public MoveAbility(int value, List<BaseAbility> subabilities = null, List<Element> cost = null) : base(Ability.Move, value, subabilities, cost)
        {
            Jump = false;
        }
        public MoveAbility(int value, bool jump, List<BaseAbility> subabilities = null, List<Element> cost = null) : this(value)
        {
            Jump = true;
        }

        public bool Jump { get; protected set; }
    }
}
