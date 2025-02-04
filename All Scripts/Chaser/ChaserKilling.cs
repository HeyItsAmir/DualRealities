using Unity.VisualScripting;
using UnityEngine;

public class ChaserKilling : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
