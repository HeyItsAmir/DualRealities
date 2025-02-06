using Unity.VisualScripting;
using UnityEngine;

public class OpenGatePlate : MonoBehaviour
{
    [SerializeField]
    GameObject gate;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Active();
        }
    }

    void Active()
    {
        //animation
        Destroy(gate);
    }
}
