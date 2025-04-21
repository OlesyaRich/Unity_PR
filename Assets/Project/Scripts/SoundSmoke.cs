using UnityEngine;

public class SoundSmoke : MonoBehaviour
{
    public AudioSource FlameSound;
    public AudioSource SmokeSound;

    public void PlaySound()
    {
        if (!FlameSound.isPlaying)
        {
            FlameSound.Play();
            SmokeSound.Play();
        }
    }
}
