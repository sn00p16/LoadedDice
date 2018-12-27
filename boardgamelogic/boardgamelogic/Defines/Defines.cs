namespace boardgamelogic.Defines
{
    public enum RotationDirection
    {
        Clockwise,
        Anticlockwise,
    }

    public enum DeckPosition
    {
        Top,
        Middle,
        Bottom,
    }

    public enum PlayingCardSuit
    {
        Undefined = -1,

        Club,
        Diamond,
        Heart,
        Spade,

        Count
    }

    public enum PlayingCardRank
    {
        Joker = -1,

        Undefined = 0,

        Ace,
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack,
        Queen,
        King,

        Count
    }

    public enum CoinFace
    {
        Undefined = 0,

        Heads,
        Tails
    }
}