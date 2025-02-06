using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 10f;

    private MusicRandomPlay music;
    public GameObject GameOverUI;
    void Start()
    {
        GameOverUI.SetActive(false);
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
