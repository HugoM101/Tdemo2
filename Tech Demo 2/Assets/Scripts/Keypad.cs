using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private Image AnsBack;
    [SerializeField] private GameObject Door;
    public Canvas KeyPad;

    private string Answer = "68535";

    private Color correctColor = Color.green;
    private Color incorrectColor = Color.red;
    public AudioSource audioSource; // Reference to your Audio Source component

    // Play a voice-over clip
    public void PlayVoiceOver(AudioClip voiceOverClip)
    {
        audioSource.PlayOneShot(voiceOverClip);
    }

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if (Ans.text == Answer)
        {
            Ans.text = "Correct";
            AnsBack.color = correctColor; // Change the text color to green
            Destroy(Door); // Destroy the Door GameObject
        }
        else
        {
            Ans.text = "Invalid";
            AnsBack.color = incorrectColor; // Change the text color to red
        }
    }

    public void ClearField()
    {
        Ans.text = "";
        AnsBack.color = Color.white; // Reset the text color to white
    }

    public void Exit()
    {
        KeyPad.enabled = false;
    }
}