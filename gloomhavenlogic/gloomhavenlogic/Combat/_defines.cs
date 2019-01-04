using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public enum Ability
    {
        Undefined = -1,

        Attack,
        Move,
        Push,
        Pull,
        Pierce,
        AddTarget,
        Heal,
        Retaliate,
        Shield,

        Max
    }

    public enum Condition
    {
        Undefined = -1,

        Poison,
        Wound,
        Immobilize,
        Disarm,
        Stun,
        Muddle,
        Strengthen,
        Curse,
        Bless,
        Invisible,

        Max
    }

    public enum Element
    {
        Undefined = -1,

        Fire,
        Ice,
        Earth,
        Wind,
        Light,
        Dark,

        Max
    }

    public enum AttackModifierType
    {
        Undefined = -1,

        Standard,
        Critical,
        Miss,

        Max
    }

    public enum AttackModifierPull
    {
        Undefined = -1,

        Standard,
        Advantaged,
        Disadvantaged,

        Max
    }
}
