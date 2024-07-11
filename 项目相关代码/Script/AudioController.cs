using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip attackSource;
    public AudioClip skillClip;
    public AudioClip skillSaying1;
    public AudioClip skillSaying2;
    public AudioClip skillSaying3;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play_music(AudioClip myClip)
    {
        audioSource.clip = myClip;
        audioSource.Play();
    }
}
