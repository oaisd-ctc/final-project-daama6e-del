using System;
using UnityEngine;

public class AudioAskerEvent : MonoBehaviour
{

    public NarratorScript request;

    void Start()
    {
        //NarratorScript request = new NarratorScript();
        request.PlayOneShot(narratorClips.INTRO);
    }
}
