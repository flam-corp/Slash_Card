using UnityEngine;
using TMPro;

public class SafeArea : MonoBehaviour
{
    private RectTransform Panel;
    private Rect rect;

    void Awake()
    {
        Panel = GetComponent<RectTransform>();

        ApplySafeArea();
    }

    void ApplySafeArea()
    {
        rect = Screen.safeArea;
        var area = Screen.height - rect.height;

        Panel.sizeDelta = new Vector2(Panel.sizeDelta.x, Panel.sizeDelta.y + area);
    }
}