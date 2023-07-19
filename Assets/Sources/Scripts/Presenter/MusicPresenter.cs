using CrazyRacing.Model;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip[] _templates;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        if (Audio.IsEnabled)
            Play();
    }

    private void Update()
    {
        if (Audio.IsEnabled)
        {
            if (GamePauseController.IsPaused == false)
            {
                if (_audioSource.isPlaying == false)
                    Play();
            }
        }
    }

    private void Play()
    {
        int randomNumber = Random.Range(0, _templates.Length);
        _audioSource.clip = _templates[randomNumber];
        _audioSource.Play();
    }
}
