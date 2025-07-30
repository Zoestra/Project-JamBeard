using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite speakerOnIcon;
    public Sprite speakerOffIcon;

    private bool isMuted = false;

    public void ToggleMusic()
    {
        Button musicButton = GameObject.Find("MusicOn").GetComponent<Button>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            isMuted = false;
        }
        else
        {
            isMuted = !isMuted;
            audioSource.mute = isMuted;
        }

        UpdateMusicButtonIcon(musicButton);
    }

    private void UpdateMusicButtonIcon(Button musicButton)
    {
        if (isMuted)
            musicButton.image.sprite = speakerOnIcon;
        else
            musicButton.image.sprite = speakerOffIcon;
    }
}
