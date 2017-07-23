using UnityEngine;

public class SoundMuteScript : MonoBehaviour
{
    public AudioSource audioSource;
    public UIControllerScript uiController;

    public void ChangeSoundState()
    {
        audioSource.enabled = !audioSource.enabled;
        if (uiController != null)
            uiController.SetSoundActive(audioSource.enabled);
    }
}