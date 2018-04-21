using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Sound Manager Singleton
    public static SoundManager Instance = null;

    // Audio Clips
    public AudioClip goal;
    public AudioClip loss;
    public AudioClip paddleHit;
    public AudioClip Win;
    public AudioClip wallHit;

    private AudioSource soundEffectAudio;

    private void Start () {
        // Singleton Pattern
        if (Instance == null)   // Ensure only this one can exist
            Instance = this;
        else if (Instance != this)  // It's not this SoundManager, destroy it
            Destroy(gameObject);

        AudioSource[] sources = GetComponents<AudioSource>();

        // Loop through every audio source clip
        foreach (AudioSource source in sources) {
            if (source.clip == null)
                soundEffectAudio = source;      // Set the clip to the audio source
        }
	}

    // Receives an plays an audio clip
    public void PlayOneShot(AudioClip clip) {
        soundEffectAudio.PlayOneShot(clip);
    }

}
