using UnityEngine;

public class Enemyyy : MonoBehaviour
{
    public float health = 50f;
    public void TakeDamage(float damage)
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
}