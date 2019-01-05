using boardgamelogic.BaseComponents;
using boardgamelogic.Collections;
using gloomhavenlogic.Combat.Modifiers;
using gloomhavenlogic.Party;
using System;
using System.Collections.Generic;
using System.Text;

namespace gloomhavenlogic.Combat
{
    public sealed class AttackModifierController
    {
        private const int SingleAdjustCards = 5;
        private const int NonAdjustCards = 6;

        public AttackModifierController()
        {
        }

        private Dictionary<PlayerPosition, Deck> ModifierDecks { get; set; }
        private Dictionary<PlayerPosition, Deck> DiscardDecks { get; set; }
        private Dictionary<PlayerPosition, List<Card>> ActiveCards { get; set; }

        public int CalculateDamage(PlayerPosition deck, AttackModifierPull pull_type, int attack_value)
        {
            // Draw modifier cards
            DrawModifierCards(deck, pull_type);

            return 0;
        }

        public void ModifyDeck(PlayerPosition deck, List<Card> cardsToAdd, List<Card> cardsToRemove)
        {
            // Remove cards from the modifier deck
            if (cardsToRemove != null)
            {
                while (cardsToRemove.Count > 0)
                {
                    ModifierDecks[deck].Cards.Remove(cardsToRemove[0]);
                    cardsToRemove.RemoveAt(0);
                }
            }

            // Add new cards to the deck, and shuffle
            if (cardsToAdd != null && cardsToAdd.Count > 0)
                ModifierDecks[deck].AddToDeck(cardsToAdd, true);
        }

        private void DrawModifierCards(PlayerPosition deck, AttackModifierPull pull_type)
        {
            DiscardCurrentCards(deck);
            ActiveCards[deck].AddRange(ModifierDecks[deck].Draw(pull_type == AttackModifierPull.Standard ? 1 : 2));
        }

        private void DiscardCurrentCards(PlayerPosition deck)
        {
            bool shuffle = false;
            foreach (var card in ActiveCards[deck])
                shuffle |= (card as AttackModifierCard).Shuffle;

            DiscardDecks[deck].Cards.AddRange(ActiveCards[deck]);
            ActiveCards[deck].Clear();

            if (shuffle)
            {
                var cards = DiscardDecks[deck].Draw(DiscardDecks[deck].Cards.Count);
                ModifierDecks[deck].AddToDeck(cards, true);
            }
        }

        private void CreateDefaultDecks()
        {
            // Standard deck of 20 cards
            var standardCards = new List<Card>
            {
                new AttackModifierCard(new List<AttackModifier> { new DamageMultiplierModifier(2) }, true, false),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+2) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(+1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(0) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-1) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageAdjustModifier(-2) }),
                new AttackModifierCard(new List<AttackModifier> { new DamageMultiplierModifier(0) }, true, false)
            };

            // Add the standard cards to 
            foreach (var deck in ModifierDecks)
                deck.Value.AddToDeck(standardCards, true);
        }

        #region Singleton Implementation

        private static AttackModifierController instance = null;
        private static readonly object padlock = new object();

        public static AttackModifierController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AttackModifierController();
                    }
                    return instance;
                }
            }
        }

        #endregion
    }
}
