using UnityEngine;
using UnityEngine.UI;
public class VolumeAdjuster : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        volumeAudio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        volumeSlider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void VolumeController(){
        volumeAudio.volume = volumeSlider.value;
    }
}
