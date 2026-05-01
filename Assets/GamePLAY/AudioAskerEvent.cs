using System;
using UnityEngine;

public class AudioAskerEvent : MonoBehaviour
{
    [SerializeField] private narratorClips clipToPlay;

    void OnEnable()
    {
        NarratorScript.instance.PlayOneShot(clipToPlay);
    }
}
