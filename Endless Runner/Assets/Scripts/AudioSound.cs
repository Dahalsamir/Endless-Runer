using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour
{
    public Sound[] sound;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sound s in sound)
        {
            s.sources = gameObject.AddComponent<AudioSource>();
            s.sources.clip = s.clip;
            s.sources.loop = s.loop;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound("MainTheme");
        
    }
    public void PlaySound(string name)
    {
        foreach (Sound s in sound)
        {
           if(s.name == name)
            {
                s.sources.Play();
            }
        }
    }
}
