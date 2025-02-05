using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    // Start is called before the first frame update
    void Start()
    {
        playRandom();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying && Time.timeScale > 0)
        {
            playRandom();
        }
    }
    void playRandom()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
    }
}
