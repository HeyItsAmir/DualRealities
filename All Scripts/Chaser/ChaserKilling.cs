using Unity.VisualScripting;
using UnityEngine;

public class ChaserKilling : MonoBehaviour
{
    private MusicRandomPlay music;
    public GameObject GameOverUI;

    private void Start()
    {
        GameOverUI.SetActive(false);
     //   music = FindAnyObjectByType<MusicRandomPlay>();
    }
    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            if (music != null)
            {
                music.audioSource.Pause();
            }
        }
    }

}
