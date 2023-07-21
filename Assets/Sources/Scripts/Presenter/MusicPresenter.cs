using CrazyRacing.Model;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPresenter : MonoBehaviour
{
    [SerializeField] private AudioClip[] _templates;

    private AudioSource _audioSource;
    private AudioClip _lastClip;

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

        if (_templates[randomNumber] == _lastClip)
        {
            while (_templates[randomNumber] == _lastClip)
                randomNumber = Random.Range(0, _templates.Length);
        }

        _lastClip = _templates[randomNumber];
        _audioSource.clip = _templates[randomNumber];
        _audioSource.Play();
    }
}
