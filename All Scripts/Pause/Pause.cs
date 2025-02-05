using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private MusicRandomPlay musicRandomPlay;
    private bool IsPause = false;
    // Start is called before the first frame update
    void Start()
    {
        musicRandomPlay = FindObjectOfType<MusicRandomPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (IsPause)
            {
                ResumeGame();
                if (musicRandomPlay != null && !musicRandomPlay.audioSource.isPlaying)
                {
                musicRandomPlay.audioSource.UnPause();
                }
            }
            else
            {
                PauseGame();
                if (musicRandomPlay != null)
                {
                musicRandomPlay.audioSource.Pause();
                }
            }
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        IsPause = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        IsPause = false;
    }
}
