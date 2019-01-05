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
            Modifiers = new List<AttackModifier>();

            Shuffle = false;
            RollOn = false;
        }
        public AttackModifierCard(List<AttackModifier> modifiers) : this()
        {
            Modifiers.AddRange(modifiers);
        }
        public AttackModifierCard(List<AttackModifier> modifiers, bool shuffle, bool rollon) : this(modifiers)
        {
            Shuffle = shuffle;
            RollOn = rollon;
        }

        public List<AttackModifier> Modifiers { get; protected set; }
        
        public bool Shuffle { get; protected set; }
        public bool RollOn { get; protected set; }
    }
}
