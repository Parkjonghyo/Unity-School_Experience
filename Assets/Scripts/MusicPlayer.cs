using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SetMp3(AudioClip music)
    {
        if (_audioSource.clip != music)
        {
            _audioSource.Stop();
            _audioSource.clip = music;
            _audioSource.time = 0;
            _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
            _audioSource.clip = null;
        }
    }
    
}
