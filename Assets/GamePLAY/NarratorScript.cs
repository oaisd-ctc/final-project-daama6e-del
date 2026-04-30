using UnityEngine.Audio;
using UnityEngine;
using JetBrains.Annotations;

public enum narratorClips
{
    INTRO,
    RADIOON,
    TOASTERON,
    WHILETOASTING,
    AFTERTTOASTING,
    WRONGTAKE,
    CORRECTTAKE,
    PARSETAKE,

}

[System.Serializable]
public class NarratorVoiceListing //Labeling
{
    public narratorClips label;
    public AudioClip clip;
}

public class NarratorScript : MonoBehaviour
{
    public static NarratorScript instance;
    public NarratorVoiceListing[] soundList; //Having this look at Narrator Clips enum was what throwing you off bud.
    
    void Awake()
    {
        instance = this;
    }
    public void PlayOneShot(narratorClips requestedAudio) //Remember! this passes in data in a form.
    {
        float volume = 1; //Controls volume universally for this audio
        foreach (NarratorVoiceListing clip in soundList)
        {
            if (clip.label == requestedAudio) //There we go finally fixed the comparator, it wants to eat the whole data packet.
            {
                GetComponent<AudioSource>().PlayOneShot(clip.clip, volume);
                return; //When its found, stop looking via looping.
            }
        }
    }
}

