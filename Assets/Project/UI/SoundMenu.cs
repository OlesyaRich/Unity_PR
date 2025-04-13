using UnityEngine;

public class SoundMenu : MonoBehaviour
{
    public AudioSource ButtonSound;

    public void PlaySound()
    {
        if (!ButtonSound.isPlaying)
        {
            ButtonSound.Play();
        }
    }
}