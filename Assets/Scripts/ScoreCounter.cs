using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreTMP;

    public int score { get; private set; }

    void Start()
    {
        SetTMP();
    }

    public void AddPoint()
    {
        score++;
        SetTMP();
    }

    private void SetTMP()
    {
        scoreTMP.text = score.ToString();
    }
}
