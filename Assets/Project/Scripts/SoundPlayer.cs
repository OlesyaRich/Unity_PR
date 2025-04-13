using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource RunSound;
    public AudioSource JumpSound;
    public AudioSource ButtonSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlaySound(RunSound);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            SoundOff(RunSound);
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Прыжок
        {
            PlaySound(JumpSound);
        }

        if (Input.GetKeyDown(KeyCode.F)) //Взаимодействие с кнопкой
        {
            PlaySound(ButtonSound);
        }
    }

    public void PlaySound(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    public void SoundOff(AudioSource source)
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
    }
}
