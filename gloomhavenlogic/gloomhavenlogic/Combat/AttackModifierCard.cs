using boardgamelogic.BaseComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public class AttackModifierCard : Card
    {
        public AttackModifierCard() : base()
        {
            Type = AttackModifierType.Undefined;
            Ability = SecondaryAbility.Undefined;
            Condition = Condition.Undefined;
            Element = Element.Undefined;

            Value = 0;
            Shuffle = false;
            RollOn = false;
        }
        public AttackModifierCard(AttackModifierType type, int value) : this()
        {
            Type = type;
            Value = value;
        }
        public AttackModifierCard(AttackModifierType type, int value, bool shuffle, bool rollon) : this(type, value)
        {
            Shuffle = shuffle;
            RollOn = rollon;
        }
        public AttackModifierCard(SecondaryAbility ability, int value, bool shuffle, bool rollon) : this(AttackModifierType.Standard, value, shuffle, rollon)
        {
            Ability = ability;
        }
        public AttackModifierCard(Condition condition, int value, bool shuffle, bool rollon) : this(AttackModifierType.Standard, value, shuffle, rollon)
        {
            Condition = condition;
        }
        public AttackModifierCard(Element element, int value, bool shuffle, bool rollon) : this(AttackModifierType.Standard, value, shuffle, rollon)
        {
            Element = element;
        }

        public AttackModifierType Type { get; protected set; }
        public SecondaryAbility Ability { get; protected set; }
        public Condition Condition { get; protected set; }
        public Element Element { get; protected set; }

        public int Value { get; protected set; }
        public bool Shuffle { get; protected set; }
        public bool RollOn { get; protected set; }
    }
}
