using UnityEngine;

public class CardModel
{
    public Sprite currentFace;
    public Suit suit;
    public int cardIndex;

    public CardModel(Sprite face, Suit _suit, int index)
    {
        currentFace = face;
        suit = _suit;
        cardIndex = index;
    }
}

