using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardLogic : MonoBehaviour
{
    [SerializeField] private Transform boardCenter;

    private Image spriteRenderer;

    public AnimationCurve scaleCurve;
    [SerializeField] private float duration = 0.5f;

    private Sprite frontImage;
    public int cardIndex { get; private set; }

    public Suit suit;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<Image>();
    }

    public void SetData(CardModel model, int index)
    {
        frontImage = model.currentFace;
        cardIndex = index;
        suit = model.suit;
    }

    public void FlipCard()
    {
        StartCoroutine(Flip());
    }

    IEnumerator Flip()
    {
        float time = 0f;
        while (time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time = time + Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                spriteRenderer.sprite = frontImage;
            }

            yield return new WaitForFixedUpdate();
        }
    }
}