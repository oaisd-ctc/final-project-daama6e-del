using System;
using System.Collections;
using UnityEngine;

public class AudioAskerEvent : MonoBehaviour
{
    [SerializeField] private narratorClips clipToPlay;
    [SerializeField] private float delay = 0f;

    void OnEnable()
    {
        StartCoroutine(DelayPlay()); //Forgot the tag, why it wont work. StartCorutine is important.
    }

    IEnumerator DelayPlay()
    {
        if (clipToPlay != null)
        {

            yield return new WaitForSeconds(delay); //you see its got the variable in it. yeild is used to tag it as a working timer instead of thread.sleep.
            NarratorScript.instance.PlayOneShot(clipToPlay);

            //this.gameObject.SetActive(false); //Optional incase for some reason want to have the audio play again.
        }
        else
        {
            Debug.Log("Error, there is nothing in the clips list");
        }
    }
}