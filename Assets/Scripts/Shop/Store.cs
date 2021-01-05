using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    Color currentColor;
    [SerializeField] private Image boardImage;
    public UnityAction _event;
    private bool isStart = true;
    public int index { private set; get; }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("R"))
        {
            currentColor = new Color(PlayerPrefs.GetFloat("R"), PlayerPrefs.GetFloat("G"), PlayerPrefs.GetFloat("B"));
            index = PlayerPrefs.GetInt("BoardIndex");
            SetColorBoard(currentColor, index, false);
        }
        else
        {
            SaveData(Color.white, 0);
            index = 0;
        }
        isStart = false;
    }

    public void SetColorBoard(Color color, int _index, bool isSave = true)
    {
        boardImage.color = color;
        index = _index;
        if (isSave)
        {
            SaveData(color, index);
        }
        if (!isStart)
        {
            _event.Invoke();
        }
    }

    private void SaveData(Color color, int _index) // Save data
    {
        PlayerPrefs.SetInt("BoardIndex", _index);

        PlayerPrefs.SetFloat("R", color.r);
        PlayerPrefs.SetFloat("G", color.g);
        PlayerPrefs.SetFloat("B", color.b);
        PlayerPrefs.Save();
    }
}