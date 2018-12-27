using boardgamelogic.BaseComponents;
using boardgamelogic.Collections;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public enum AttackModifierDeck
    {
        Undefined = -1,

        Player1,
        Player2,
        Player3,
        Player4,

        Monster,

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

    public class AttackModifierController
    {
        public AttackModifierController() { }

        public Dictionary<AttackModifierDeck, Deck> ModifierDecks { get; protected set; }
        public Dictionary<AttackModifierDeck, List<Card>> ActiveCards { get; protected set; }

        protected Dictionary<AttackModifierDeck, Deck> DiscardDecks { get; set; }

        public void DrawModifierCards(AttackModifierDeck deck, AttackModifierPull pull_type)
        {
            // Pull one card for standard draw, 2 for (dis)advantage
            DiscardCurrentCards(deck);
            ActiveCards[deck].AddRange(ModifierDecks[deck].Draw(pull_type == AttackModifierPull.Standard ? 1 : 2));
        }

        public int CalculateDamage(AttackModifierDeck deck, int attack_value)
        {
            var adjustCards = new List<Card>();
            var otherCards = new List<Card>();
            var currentAttackValue = attack_value;

            // Sort cards
            foreach(var card in ActiveCards[deck])
            {
                if ((card as AttackModifierCard).Type == AttackModifierType.Adjust)
                    adjustCards.Add(card);
                else
                    otherCards.Add(card);
            }

            // Adjust values
            foreach (var card in adjustCards)
                currentAttackValue += (card as AttackModifierCard).Value;

            // Double or Nothing
            foreach(var card in otherCards)
            {
                if ((card as AttackModifierCard).Type == AttackModifierType.Multiplier)
                    currentAttackValue *= (card as AttackModifierCard).Value;
                else
                    currentAttackValue = 0;
            }

            return currentAttackValue;
        }

        protected void DiscardCurrentCards(AttackModifierDeck deck)
        {
            bool shuffle = false;
            foreach (var card in ActiveCards[deck])
                shuffle |= (card as AttackModifierCard).Shuffle;

            DiscardDecks[deck].Cards.AddRange(ActiveCards[deck]);
            ActiveCards[deck].Clear();

            if(shuffle)
                ModifierDecks[deck].AddToDeck(DiscardDecks[deck].Cards, true);
        }
    }
}
