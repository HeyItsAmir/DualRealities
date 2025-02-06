using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTrigger : MonoBehaviour
{
    
    float speed = 10f;
    public Rigidbody2D rb;
    public Rigidbody2D rb2;
    public Rigidbody2D rb3;
void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.tag == "Player")
    {
    rb.velocity = new Vector2(-speed, rb.velocity.y);
    rb2.velocity = new Vector2(-speed, rb2.velocity.y);
    rb3.velocity = new Vector2(-speed, rb3.velocity.y);
}
    }
    

}
