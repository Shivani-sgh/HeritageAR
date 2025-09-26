using UnityEngine;
using UnityEngine.UI;

public class TajMahalHistoryAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public Button playButton;
    public AudioClip tajHistoryClip;  // assign your recorded audio in Inspector

    void Start()
    {
        if (playButton != null)
            playButton.onClick.AddListener(ToggleAudio);
    }

    void ToggleAudio()
    {
        if (tajHistoryClip == null || audioSource == null)
        {
            Debug.LogWarning("AudioClip or AudioSource missing!");
            return;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();   // Stop audio if it’s playing
        }
        else
        {
            audioSource.clip = tajHistoryClip;
            audioSource.Play();   // Play audio if it’s not playing
        }
    }
}
