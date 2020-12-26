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

    private void Start()
    {
        if (PlayerPrefs.HasKey("R"))
        {
            currentColor = new Color(PlayerPrefs.GetFloat("R"), PlayerPrefs.GetFloat("G"), PlayerPrefs.GetFloat("B"));
            SetColorBoard(currentColor);
        }
        else
        {
            SaveColor(Color.white, 0);
        }
        isStart = true;
    }

    public void SetColorBoard(Color color, int index = 0)
    {
        boardImage.color = color;
        SaveColor(color, index);
        if (!isStart)
        {
            _event.Invoke();
        }
    }

    private void SaveColor(Color color, int index) // Save data
    {
        PlayerPrefs.SetInt("BoardIndex", index);

        PlayerPrefs.SetFloat("R", color.r);
        PlayerPrefs.SetFloat("G", color.g);
        PlayerPrefs.SetFloat("B", color.b);
        PlayerPrefs.Save();
    }
}