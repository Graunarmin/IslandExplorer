using System;
using UnityEngine.Audio;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (source != null)
        {
            if (source.clip != null)
            {
                source.Play();
            }
        }
    }

    public void Stop()
    {
        if (source != null)
        {
            if (source.clip != null)
            {
                source.Stop();
            }
        }
    }
}
