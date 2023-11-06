using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour
{
    public Text subtitleText;
    public float displayDuration = 3.0f; // The duration to display the subtitle in seconds

    private float displayTimer;
    private bool displayingSubtitle;

    private void Start()
    {
        HideSubtitle();
    }

    private void Update()
    {
        if (displayingSubtitle)
        {
            displayTimer -= Time.deltaTime;
            if (displayTimer <= 0)
            {
                HideSubtitle();
                
            }
        }
    }

    public void ShowSubtitle(string text)
    {
        subtitleText.text = text;
        subtitleText.gameObject.SetActive(true);
        displayTimer = displayDuration;
        displayingSubtitle = true;
    }

    public void HideSubtitle()
    {
        displayDuration = 3.0f;
        subtitleText.gameObject.SetActive(false);
        displayingSubtitle = false;
    }
}