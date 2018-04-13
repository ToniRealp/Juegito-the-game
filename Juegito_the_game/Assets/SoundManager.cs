using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public AudioSource efxSource;   
    public AudioSource musicSource;                 
    public static SoundManager instance = null;     
 

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play ();
    }


}