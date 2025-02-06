using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float speed = 20f;

    [SerializeField]
    float damage = 10f;

    float direction;

    // Start is called before the first frame update
    void Start()
    {

        if(player.transform.localScale.x > 0)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        rb.linearVelocity = new Vector2(speed * direction, rb.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy target = collision.gameObject.GetComponent<Enemy>();

            target.TakeDamage(damage);
            Explode();
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Explode();
        }
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
