using UnityEngine;

public class CardData : MonoBehaviour
{
    public Sprite[] facesD;
    public Sprite[] facesC;
    public Sprite[] facesH;
    public Sprite[] facesS;
    public Sprite cardBack;
    private Sprite sprite;

    public CardModel GetRandomData()
    {
        Suit suit = (Suit)Random.Range(0, 4);
        switch (suit)
        {
            case Suit.diamond:
                sprite = facesD[Random.Range(0, facesD.Length)];
                break;
            case Suit.club:
                sprite = facesC[Random.Range(0, facesD.Length)];
                break;
            case Suit.heart:
                sprite = facesH[Random.Range(0, facesD.Length)];
                break;
            case Suit.spade:
                sprite = facesS[Random.Range(0, facesD.Length)];
                break;
            default:
                Debug.Log("Incorrect value");
                break;
        }
        CardModel model = new CardModel(sprite, suit, 0);
        return model;
    }
}
