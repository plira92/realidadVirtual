using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Song;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Settings()
    {
        Panel.GetComponent<Animator>().SetTrigger("Pop");
    }

    public void Music()
    {
        if (Song.GetComponent<AudioSource>().isPlaying)
        {
            Song.GetComponent<AudioSource>().Pause();
        }
        else
        {
            Song.GetComponent<AudioSource>().UnPause();
        }
    }
}
