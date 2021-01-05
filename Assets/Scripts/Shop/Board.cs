using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    [SerializeField] private TMP_Text standartText;
    [SerializeField] private Item item;
    private Store store;

    private Image image;

    void Start()
    {
        store = GameObject.Find("Manager").GetComponent<Store>();
        image = GetComponent<Image>();
        image.color = item.color;

        store._event += SetTextColor;

        SetTextColor();
    }

    public void PickBoard() // Selecting a table from the store
    {
        standartText.color = Color.yellow;
        store.SetColorBoard(item.color, item.id);
    }

    private void SetTextColor() // Change text color on shop
    {
        if(store.index == item.id)
            standartText.color = Color.yellow;
        else
            standartText.color = Color.white;
    }
}