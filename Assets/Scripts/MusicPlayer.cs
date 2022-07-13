using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPerfControler.GetMasterVolume();
        if (FindObjectsOfType(this.GetType()).Length > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(this);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
