using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 1f;
    public bool PlayerIsDead;
    private MusicRandomPlay music;
    public GameObject GameOverUI;
    void Start()
    {
        GameOverUI.SetActive(false);
        music = FindAnyObjectByType<MusicRandomPlay>();
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            P1 player = collision.GetComponent<P1>();

            if (player != null)
            {
                player.Die(); 
            }

            StartCoroutine(HandleGameOver()); 
        }
    }

    IEnumerator HandleGameOver()
    {
        yield return new WaitForSeconds(2); 
        Time.timeScale = 0f;  
        GameOverUI.SetActive(true);  
    }
}


