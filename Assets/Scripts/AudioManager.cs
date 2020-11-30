using System;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{


    public Sound[] mySounds;         //create a public sounds array called sounds

    public static AudioManager instance;


    //awake function similar to the start but is called before the start function
    void Awake()
    {

        foreach(Sound s in mySounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();    //creates an audio source component that is the same source as the element from the array
            s.source.clip = s.clip;         //refrencing to its own clip
            s.source.volume = s.volume;     //refrencing to its own volume

            s.source.pitch = s.pitch;       //refrencing to its own pitch
            s.source.loop = s.loop;
        }
    }



    public void Play(string name)   //function to find and play a sound within the mySounds array
    {
        Sound s = Array.Find(mySounds, sound => sound.name == name); //finds the sound with the same name within the mySounds array as the name that was passed into the function
        s.source.Play();
    }

    public void Stop(string name)   //function to find and play a sound within the mySounds array
    {
        Sound s = Array.Find(mySounds, sound => sound.name == name); //finds the sound with the same name within the mySounds array as the name that was passed into the function
        s.source.Stop();
    }

    public void Pause(string name)   //function to find and play a sound within the mySounds array
    {
        Sound s = Array.Find(mySounds, sound => sound.name == name); //finds the sound with the same name within the mySounds array as the name that was passed into the function
        s.source.Pause();
    }



}
