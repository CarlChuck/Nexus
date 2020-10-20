using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] AudioSource audioSource = default;

    void PlaySound(AudioClip soundToPlay)
    {
        audioSource.PlayOneShot(soundToPlay);
    }
}
