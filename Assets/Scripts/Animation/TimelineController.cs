using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public void Play()
    {
        playableDirector.Play();
    }
}
