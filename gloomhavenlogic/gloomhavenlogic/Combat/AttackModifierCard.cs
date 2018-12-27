using boardgamelogic.BaseComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public enum AttackModifierType
    {
        Undefined = -1,

        Adjust,
        Multiplier,
        Miss,
        
        Max
    }

    public class AttackModifierCard : Card
    {
        public AttackModifierCard() : base() { Type = AttackModifierType.Undefined; Value = 0; }
        public AttackModifierCard(AttackModifierType type, int value) : this() { Type = type; Value = value; }

        public AttackModifierType Type { get; protected set; }
        public int Value { get; protected set; }
        public bool Shuffle { get; protected set; }
        public bool Redraw { get; protected set; }
    }
}
