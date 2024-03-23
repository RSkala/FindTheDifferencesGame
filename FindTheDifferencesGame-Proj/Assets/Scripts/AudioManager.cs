using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] _incorrectSelectionClips;
    [SerializeField] AudioClip[] _correctSelectionClips;

    public static AudioManager Instance { get; private set; }

    AudioSource _incorrectSelectionSource;
    AudioSource _correctSelectionSource;

    public enum Sfx
    {
        IncorrectSelection,
        CorrectSelection
    }

    void Start()
    {
        if(Instance != null)
        {
            Debug.LogError("AudioManager.Instance already exists!");
            Destroy(Instance);
        }
        Instance = this;

        // Instantiate AudioSource objects
        GameObject incorrectSourceGO = new GameObject("IncorrectSelectionSource");
        _incorrectSelectionSource = incorrectSourceGO.AddComponent<AudioSource>();
        _incorrectSelectionSource.playOnAwake = false;
        _incorrectSelectionSource.transform.SetParent(transform);

        GameObject correctSourceGO = new GameObject("CorrectSelectionSource");
        _correctSelectionSource = correctSourceGO.AddComponent<AudioSource>();
        _correctSelectionSource.playOnAwake = false;
        _correctSelectionSource.transform.SetParent(transform);
    }

    public void PlaySfx(Sfx sfx)
    {
        switch(sfx)
        {
            case Sfx.IncorrectSelection: PlayRandomSfxFromClips(_incorrectSelectionSource, _incorrectSelectionClips); break;
            case Sfx.CorrectSelection: PlayRandomSfxFromClips(_correctSelectionSource, _correctSelectionClips); break;
            default: break;
        }
    }

    void PlayRandomSfxFromClips(AudioSource audioSource, AudioClip[] audioClips)
    {
        if(audioClips.Length <= 0)
        {
            return;
        }

        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        int randomIdx = Random.Range(0, audioClips.Length);
        AudioClip audioClip = audioClips[randomIdx];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
