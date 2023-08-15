using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton instance
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

        audioSource = GetComponent<AudioSource>();
    }

    public static MusicManager Instance
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
}
