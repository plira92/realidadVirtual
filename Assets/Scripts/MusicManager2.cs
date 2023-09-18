/**
 * Script: MusicManager2
 * Description: This script manages music playback in a Unity game using a Singleton pattern.
 * It ensures that the audio source persists between scenes and provides functions to control music,
 * including playing, stopping, toggling, and muting.
 */
 
using UnityEngine;
using UnityEngine.UI;

public class MusicManager2 : MonoBehaviour
{
    private static MusicManager2 instance; // Singleton instance
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // Set the instance to the current object if it doesn't exist
            DontDestroyOnLoad(gameObject); // Prevent the object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this object
        }

        audioSource = FindObjectOfType<AudioSource>();
    }

    public static MusicManager2 Instance
    {
        get { return instance; }
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void StartOrStopMusic(){
        if (audioSource.isPlaying) {
            StopMusic();
        }
        else{
            StartMusic();
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public void MuteMusic()
    {
        audioSource.mute = !audioSource.mute;
    }
}
