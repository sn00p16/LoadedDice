using System;
using System.Collections.Generic;
using System.Text;
using boardgamelogic.BaseComponents;

namespace boardgamelogic.Collections
{
    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
            RNG = new System.Random();
        }

        public Deck(List<Card> cards) : this()
        {
            Cards = cards;
        }

        public List<Card> Cards { get; protected set; }
        protected System.Random RNG { get; set; }

        public List<Card> Draw(int count = 1)
        {
            // Needs to be re-written
            return Cards;
        }

        public void AddToDeck(List<Card> cards, bool shuffle = true)
        {
            Cards.AddRange(cards);
            if (shuffle)
                Shuffle();
        }

        public void Shuffle()
        {
            if (Cards.Count == 0)
                return;

            var newTempDeck = new List<Card>();
            newTempDeck.AddRange(Cards);

            var count = newTempDeck.Count;
            while (count > 0)
            {
                var index = RNG.Next(count);
                Cards.Add(newTempDeck[index]);
                newTempDeck.RemoveAt(index);
                --count;
            }
        }
    }
}
