using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using boardgamelogic.BaseComponents;
using boardgamelogic.Defines;

namespace boardgamelogic.GenericComponents
{
    public class PlayingCard : Card
    {
        #region Constructors

        public PlayingCard() : base() { }

        public PlayingCard(PlayingCardSuit suit, PlayingCardRank rank) : this()
        {
            Suit = suit;
            Rank = rank;
        }

        #endregion

        #region Fields

        public PlayingCardSuit Suit { get; protected set; }
        public PlayingCardRank Rank { get; protected set; }

        #endregion

        #region Protected Methods

        protected override int GetSortingIndex()
        {
            if (Rank == PlayingCardRank.Joker)
                return int.MaxValue;

            return ((int)Suit * (int)PlayingCardRank.Count) + (int)Rank;
        }

        #endregion
    }
}
