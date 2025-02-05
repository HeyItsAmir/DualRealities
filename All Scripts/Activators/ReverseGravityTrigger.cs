using Unity.VisualScripting;
using UnityEngine;

public class ReverseGravityTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<ReverseGravity>().ReversGravity();
            Destroy(gameObject);
        }
    }
}
