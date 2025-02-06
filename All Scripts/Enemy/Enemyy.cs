using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public float health = 50f;
    public float damage = 10f;
    public LayerMask bulletLayer;
    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletLayer == (bulletLayer | (1 << collision.gameObject.layer)))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}