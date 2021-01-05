using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cache
{
    public CardLogic logic;
    public Image image;
    public Button button;
    public GameObject card;

    public Cache(CardLogic _logic, Image _image, Button _button, GameObject _card)
    {
        logic = _logic;
        image = _image;
        button = _button;
        card = _card;
    }
}

public class HandControll : MonoBehaviour
{
    [SerializeField] private GameObject handD;
    [SerializeField] private GameObject handC;
    [SerializeField] private GameObject handH;
    [SerializeField] private GameObject handS;

    private int countD;
    private int countC;
    private int countH;
    private int countS;

    HorizontalLayoutGroup tempGroup;
    public Suit tempSuit = Suit.club;

    private const int minSpacing = -130;
    private const int maxSpacing = -115;

    List<Cache> cache = new List<Cache>();


    public void SortingCards(List<GameObject> _cards) // Called after the end of the drag animation
    {
        Сaching(true, _cards);
    }

    private void Сaching(bool isSorting, List<GameObject> cards) // Caching data for optimization
    {
        foreach (var card in cards)
        {
            var logic = card.GetComponent<CardLogic>();
            var image = card.GetComponent<Image>();
            var button = card.GetComponent<Button>();

            if(isSorting)
            {
                card.transform.SetParent(ConvertSuit(false, logic.suit).transform);
                logic.FlipCard();
            }

            cache.Add(new Cache(logic, image, button, card));
        }
        cards.Clear();
    }

    public void TurnCard() // Pick card
    {
        if (cache.Count != 0)
        {
            if (tempGroup != null)
            {
                tempGroup.spacing = minSpacing;
            }

            tempGroup = ConvertSuit(true).GetComponent<HorizontalLayoutGroup>();
            tempGroup.spacing = maxSpacing;

        }
    }

    private void ChangeColor(Suit suit) // Change color card
    {
        foreach (var card in cache)
        {
            if (card.logic.suit != suit)
                SetCardParameters(false, card);
            else
                SetCardParameters(true, card);
        }
    }

    private void SetCardParameters(bool interactive, Cache card)
    {
        card.button.enabled = interactive;
        if(interactive)
            card.image.color = Color.white;
        else
            card.image.color = Color.gray;
    }

    public void DeleteCard(GameObject _card) // Delete card from list
    {
        foreach (var card in cache)
        {
            if (_card == card.card)
            {
                cache.Remove(card);
                break;
            }
        }
    }

    private GameObject ConvertSuit(bool isRandom, Suit suit = Suit.club)
    {
        if (isRandom)
        {
            suit = MatchChek();
            ChangeColor(suit);
        }
        switch (suit)
        {
            case Suit.club:
               return handC;
            case Suit.diamond:
                return handD;
            case Suit.heart:
                return handH;
            case Suit.spade:
                return handS;
            default:
                return null;
        }
    }

    private Suit MatchChek() // Card presence check
    {
        var suit = GetRandomSuit();
        bool check = false;

        while (!check)
        {
            foreach (var card in cache)
            {
                if (card.logic.suit == suit)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {

                suit = GetRandomSuit();
            }
        }
        check = false;

        return suit;
    }

    private Suit GetRandomSuit()
    {
        int rand = Random.Range(0, 4);
        return (Suit)rand;
    }

    private void DisableSuitHand(GameObject hand)
    {
        hand.SetActive(false);
    }
}