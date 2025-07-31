using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioStitcher : MonoBehaviour
{
// Basic demonstration of a music system that uses PlayScheduled to preload and sample-accurately
// stitch two AudioClips in an alternating fashion.  The code assumes that the music pieces are
// each 16 bars (4 beats / bar) at a tempo of 140 beats per minute.
// To make it stitch arbitrary clips just replace the line
//   nextEventTime += (60.0 / bpm) * numBeatsPerSegment
// by
//   nextEventTime += clips[flip].length;
    public float bpm = 140.0f;
    public int numBeatsPerSegment = 16;
    public AudioClip[] clips = new AudioClip[2];

    private double nextEventTime;
    private int flip = 0;
    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;
    private bool playingLoop = false;

    void Start()
    {
        audioSources[0] = gameObject.GetComponent<AudioSource>();
        audioSources[1] = gameObject.AddComponent<AudioSource>();
        nextEventTime = AudioSettings.dspTime + 2.0f;
        running = true;
    }
    void Update()
    {
        if (!running)
        {
            return;
        }
        audioSources[flip].volume = GameObject.Find("Volume Slider").GetComponent<Slider>().value;

        double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime && !playingLoop)
        {
            if (flip == 1)
            {
                playingLoop = true;
                audioSources[flip].loop = true;
            }
            // We are now approx. 1 second before the time at which the sound should play,
                // so we will schedule it now in order for the system to have enough time
                // to prepare the playback at the specified time. This may involve opening
                // buffering a streamed file and should therefore take any worst-case delay into account.
            audioSources[flip].clip = clips[flip];
            audioSources[flip].PlayScheduled(nextEventTime);
            
            Debug.Log("Scheduled source " + flip + " to start at time " + nextEventTime);

            // Place the next event 16 beats from here at a rate of 140 beats per minute
            nextEventTime += clips[flip].length;

            // Flip between two audio sources so that the loading process of one does not interfere with the one that's playing out
            flip = 1 - flip;
        }
    }
}
