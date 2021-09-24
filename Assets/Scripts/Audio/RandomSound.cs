using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomSound : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioMixerGroup audioMixerGroup;
    private AudioSource source;
    

    private void Awake()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = audioMixerGroup;
        source.playOnAwake = false;
    }

    public void Play()
    {
        var sound = clips[UnityEngine.Random.Range(0, clips.Length)];
        source.PlayOneShot(sound);
    }
}
