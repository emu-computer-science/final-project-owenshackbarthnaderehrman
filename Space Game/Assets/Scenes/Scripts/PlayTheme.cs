using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheme : MonoBehaviour
{
    private static GameObject instance = null;

    public AudioSource _audioSource;
     private void Awake()
     {
        if (instance == null)
        {
            instance = transform.gameObject;
            DontDestroyOnLoad(transform.gameObject);
        }
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
}
