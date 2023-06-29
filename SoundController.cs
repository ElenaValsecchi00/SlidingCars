using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //Variables
    private AudioClip point;
    private AudioClip death;
    private AudioClip pedestrian;
    private AudioSource adSrc;
    // Start is called before the first frame update
    void Start()
    {
        point = Resources.Load<AudioClip>("Sounds/PointSound");
        death = Resources.Load<AudioClip>("Sounds/DeathSound");
        pedestrian = Resources.Load<AudioClip>("Sounds/PedestrianSquash");
        adSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Change background music
    public void ChangeBGMusic()
    {
        AudioSource[] adSrcs = GetComponents<AudioSource>();
        AudioSource currentMusic = adSrcs[1].isPlaying == true ? adSrcs[1] : adSrcs[2];
        AudioSource newMusic = adSrcs[1].isPlaying == true ? adSrcs[2] : adSrcs[1];
        currentMusic.Stop();
        newMusic.Play();
    }

    //Play Clip
    public void PlayClip(string clip)
    {
        switch(clip)
        {
            case "point": adSrc.PlayOneShot(point);
                break;
            case "pedestrian": adSrc.PlayOneShot(pedestrian);
                break;
            case "death": adSrc.Stop(); adSrc.PlayOneShot(death);
                break;
        }
    }
}
