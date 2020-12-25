using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject handD;
    [SerializeField] private GameObject handC;
    [SerializeField] private GameObject handH;
    [SerializeField] private GameObject handS;

    private CardData cardData;
    private CardLogic logic;

    [SerializeField] private int countCard;
    [SerializeField] private GameObject cardPrefab;

    List<GameObject> cards = new List<GameObject>();

    private void Awake()
    {
        cardData = GetComponent<CardData>();
    }

    private void Start()
    {
        for (int i = 0; i < countCard; i++)
        {
            GenerateCard(i);
        }
    }

    private void GenerateCard(int index)
    {
        var card = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        card.transform.SetParent(gameObject.transform);
        card.transform.localScale = new Vector3(1f,1f,1f);
        logic = card.GetComponent<CardLogic>();
        logic.SetData(cardData.GetRandomData(), index);

        cards.Add(card);
    }

    public void SortingCards() // Called after the end of the drag animation
    {
        foreach (var card in cards)
        {
            var logic = card.GetComponent<CardLogic>();
            switch (logic.suit)
            {
                case Suit.club:
                    card.transform.SetParent(handC.transform);
                    break;
                case Suit.diamond:
                    card.transform.SetParent(handD.transform);
                    break;
                case Suit.heart:
                    card.transform.SetParent(handH.transform);
                    break;
                case Suit.spade:
                    card.transform.SetParent(handS.transform);
                    break;
                default:
                    break;
            }
            logic.FlipCard();
        }
    }
}