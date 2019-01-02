﻿using boardgamelogic.BaseComponents;
using boardgamelogic.Collections;
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

            var adjustCards = new List<Card>();
            var otherCards = new List<Card>();
            var currentAttackValue = attack_value;

            // Sort cards
            foreach(var card in ActiveCards[deck])
            {
                if ((card as AttackModifierCard).Type == AttackModifierType.Standard)
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
                if ((card as AttackModifierCard).Type == AttackModifierType.Critical)
                    currentAttackValue *= (card as AttackModifierCard).Value;
                else
                    currentAttackValue = 0;
            }

            return currentAttackValue;
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
                new AttackModifierCard(AttackModifierType.Critical, 2, true, false),    // 2x Critical
                new AttackModifierCard(AttackModifierType.Miss, 0, true, false),        // Miss
                new AttackModifierCard(AttackModifierType.Standard, +2),                  // +2
                new AttackModifierCard(AttackModifierType.Standard, +1),                  // +1
                new AttackModifierCard(AttackModifierType.Standard, +1),                  // +1
                new AttackModifierCard(AttackModifierType.Standard, +1),                  // +1
                new AttackModifierCard(AttackModifierType.Standard, +1),                  // +1
                new AttackModifierCard(AttackModifierType.Standard, +1),                  // +1
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, 0),                   // 0
                new AttackModifierCard(AttackModifierType.Standard, -1),                  // -1
                new AttackModifierCard(AttackModifierType.Standard, -1),                  // -1
                new AttackModifierCard(AttackModifierType.Standard, -1),                  // -1
                new AttackModifierCard(AttackModifierType.Standard, -1),                  // -1
                new AttackModifierCard(AttackModifierType.Standard, -1),                  // -1
                new AttackModifierCard(AttackModifierType.Standard, -2)                   // -2
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
