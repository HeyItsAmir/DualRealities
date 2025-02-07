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
    //public GameObject Health1, Health2, Health3; 
    private int currentHealth = 3;
    private bool canTakeDamage = true; 
    void Start()
    {
   //     GameOverUI.SetActive(false);
     //   music = FindAnyObjectByType<MusicRandomPlay>();
     //  rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
  //          P1 player = collision.GetComponent<P1>();


    //    StartCoroutine(DamageCooldown());
          }
        
    }

 //   IEnumerator DamageCooldown()
  //  {
 //       canTakeDamage = false;
 //       yield return new WaitForSeconds(0.1f); 
//        canTakeDamage = true;
 //   }




