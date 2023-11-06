using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip voiceOverClip; // Add a field for the voice-over AudioClip

    // Play a voice-over clip
    private void Start()
    {
        if (voiceOverClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(voiceOverClip);
        }
    }
}
