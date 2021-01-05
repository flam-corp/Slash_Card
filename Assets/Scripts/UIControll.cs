using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControll : MonoBehaviour
{
    [SerializeField] private GameObject startPannel;
    [SerializeField] private GameObject pausePannel;

    [SerializeField] private Animator storeAnimator;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void HideMenu()
    {
        Time.timeScale = 1f;

        startPannel.SetActive(false);
    }

    public void OpenPause()
    {
        Time.timeScale = 0f;

        pausePannel.SetActive(true);
    }

    public void HidePause()
    {
        Time.timeScale = 1f;

        storeAnimator.SetBool("Hide", true);

        //pausePannel.SetActive(false);
    }
}