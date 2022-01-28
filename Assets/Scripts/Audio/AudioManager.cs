using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip defaultMusic, sadMusic, neutralMusic;
    public static AudioManager instance;
    private AudioSource track1, track2;
    private bool isPlayingTrack1;

    public bool isHappy, isNeutral, isSad;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void CheckMood(int currentMood)
    {
        if(currentMood == 1)
        {
            isSad = true;
            isNeutral = false;
            isHappy = false;
        }
        else if(currentMood == 2)
        {
            isSad = false;
            isNeutral = true;
            isHappy = false;
        }
        else if(currentMood == 3)
        {
            isSad = false;
            isNeutral = false;
            isHappy = true;
        }
    }

    private void Start()
    {
        isHappy = true;
        track1 = gameObject.AddComponent<AudioSource>();
        track2 = gameObject.AddComponent<AudioSource>();
        track1.loop = true;
        track2.loop = true;
        isPlayingTrack1 = true;

        SwapTrack(defaultMusic);
    }
    public void SwapTrack(AudioClip newClip)
    {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(newClip));
        isPlayingTrack1 = !isPlayingTrack1;
    }
     public void ReturnToDefault()
    {
        SwapTrack(defaultMusic);
        /*
        if(isHappy == true)
        SwapTrack(defaultMusic);
        if(isSad == true)
            SwapTrack(sadMusic);
        if (isNeutral == true)
            SwapTrack(neutralMusic);*/
    }

    private IEnumerator FadeTrack(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElapsed = 0f;

        float maxVol = 0.1f;

      

        if (isPlayingTrack1)
        {
            track2.clip = newClip;
            track2.Play();
            while (timeElapsed < timeToFade)
            {
                track2.volume = Mathf.Lerp(0, maxVol, timeElapsed / timeToFade);
                track1.volume = Mathf.Lerp(maxVol, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track1.Stop();
        }
        else
        {
            track1.clip = newClip;
            track1.Play();
            while (timeElapsed < timeToFade)
            {
                track1.volume = Mathf.Lerp(0, maxVol, timeElapsed / timeToFade);
                track2.volume = Mathf.Lerp(maxVol, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            track2.Stop();
        }
    }
}
