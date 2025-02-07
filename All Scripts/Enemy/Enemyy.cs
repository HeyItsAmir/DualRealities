using UnityEngine;

public class Enemyy : MonoBehaviour
{
    public float health = 50f;
    public LayerMask bulletLayer;
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
        ScoreManager.instance.AddScore(5);
        Destroy(gameObject);
    }
}