using UnityEngine;

public class PickCard : MonoBehaviour
{
    private ScoreCounter counter;
    private Transform marker;
    private HandControll hand;

    private bool isMove = false;

    private void Awake()
    {
        counter = GameObject.Find("Manager").GetComponent<ScoreCounter>();
        marker = GameObject.Find("Marker").GetComponent<Transform>();
        hand = GameObject.Find("Hand").GetComponent<HandControll>();
    }

    private void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, marker.position, Time.deltaTime * 1.5f);
        }
    }

    public void EnterCard()
    {
        gameObject.transform.SetParent(marker);
        isMove = true;

        counter.AddPoint();

        hand.DeleteCard(gameObject);
        hand.TurnCard();

        Destroy(gameObject, 3f);
    }
}