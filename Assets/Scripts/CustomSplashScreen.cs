using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CustomSplashScreen : MonoBehaviour
{
    AudioSource audioSource;
    float clip_len;
    float timer = 0;
    bool hasStarted = false;
    bool startedFadeIn = false;
    Image waffleDemonSplash;
    void Start()
    {
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        clip_len = audioSource.clip.length;
        waffleDemonSplash = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
    }
    public void Update()
    {
        if (audioSource.isPlaying)
        {
            hasStarted = true;
        }
        Debug.Log(timer);
        if (hasStarted)
        {
            timer += Time.deltaTime;
            if (timer >= clip_len + 0.6f)
            {
                TimerEnded();
                hasStarted = false;
            }
        }
    }

    void TimerEnded()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

}
