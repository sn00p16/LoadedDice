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
        public MoveAbility(int value) : base(Ability.Move, value)
        {
            Jump = false;
        }
        public MoveAbility(int value, bool jump) : this(value)
        {
            Jump = true;
        }

        public bool Jump { get; protected set; }
    }
}
