using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private HandControll hand;

    private CardData cardData;
    private CardLogic logic;

    [SerializeField] private int countCard;
    [SerializeField] private GameObject cardPrefab;

    List<GameObject> cards = new List<GameObject>();

    private HorizontalLayoutGroup layoutGroup;
    private bool isStart = true;

    private void Awake()
    {
        cardData = GetComponent<CardData>();
        layoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    private void Start()
    {
        for (int i = 0; i < countCard; i++)
        {
            GenerateCard(i);
        }
    }

    private void Update()
    {
        if (isStart) // Start animation 
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, hand.gameObject.transform.position, Time.deltaTime * 1.6f);
            layoutGroup.spacing = Mathf.Lerp(layoutGroup.spacing, -250, Time.deltaTime * 1f);
            if (Vector3.Distance(transform.position, hand.gameObject.transform.position) <= 15)
            {
                isStart = false;
                HandSorting();
            }
        }
    }

    private void GenerateCard(int index) // Random card generation on start
    {
        var card = Instantiate(cardPrefab, transform.position, Quaternion.identity);
        card.transform.SetParent(gameObject.transform);
        card.transform.localScale = new Vector3(1f,1f,1f);
        logic = card.GetComponent<CardLogic>();
        logic.SetData(cardData.GetRandomData(), index);

        cards.Add(card);
    }

    private void HandSorting() // Sort card on suit
    {
        hand.SortingCards(cards);
        hand.TurnCard();
    }
}