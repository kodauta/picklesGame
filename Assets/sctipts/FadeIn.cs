using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    AudioSource audioSource;
    public float plusVolume;
    public float maxVolume;
 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }
 
    void Update()
    {
        if (audioSource.volume < maxVolume)
        {
            audioSource.volume += plusVolume;
        }
    } 
}
