using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;
    }

    public void Play()
    {
        var sound = clips[UnityEngine.Random.Range(0, clips.Length)];
        source.PlayOneShot(sound);
    }
}
