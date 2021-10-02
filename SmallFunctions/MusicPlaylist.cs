using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlaylist : MonoBehaviour
{
    public string[] clips;
    public AudioSource aSource;
    int i = 0;
    public bool playFirstOnlyOnce = false;
    public float delayBetweenSongs = 0;
    public float volume = 1;

	void Start ()
    {
        aSource = GetComponent<AudioSource>();
        StartAudio();
        aSource.volume = volume;
	}	

    void StartAudio()
    {
        if (clips.Length != 0)
        {
            aSource.clip = Resources.Load("Sound/Music/" + clips[i]) as AudioClip;
            aSource.Play();

            i++;
            if (i >= clips.Length)
            {
                if (playFirstOnlyOnce == true)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
            }
            Invoke("startAudio", aSource.clip.length + delayBetweenSongs);
        }

    }
}
