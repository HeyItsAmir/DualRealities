using UnityEngine;

public class Pause : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private MusicRandomPlay musicRandomPlay;
    private bool IsPause = false;
    public GameObject GameOverUI;
    public GameObject GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        GameOverUI.SetActive(false);
        musicRandomPlay = FindObjectOfType<MusicRandomPlay>();
        musicRandomPlay.audioSource.Pause();
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
                    GameOverUI.SetActive(false);
                    GameOverText.SetActive(true);
                    musicRandomPlay.audioSource.UnPause();
                }
            }
            else
            {
                PauseGame();
                if (musicRandomPlay != null)
                {
                    GameOverUI.SetActive(true);
                    GameOverText.SetActive(false);
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
