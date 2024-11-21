using UnityEngine; //Erina

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic; // Assign in Inspector

    public void TurnSoundOff()
    {
        backgroundMusic.Pause();
    }

    public void TurnSoundOn()
    {
        backgroundMusic.UnPause();
    }
}
