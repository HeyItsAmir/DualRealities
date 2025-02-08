using Unity.VisualScripting;
using UnityEngine;

public class ReverseGravityTrigger : MonoBehaviour
{
    public ReverseGravity reverseGravity;
    public ReverseGravity2 reverseGravity2;
    public GameObject Player2;
    private void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("revers");
            //reverseGravity.isReverse = true;
            //reverseGravity2.isReverse = true;
            collision.GetComponent<ReverseGravity>().ReversGravity();
            collision.GetComponent<ReverseGravity2>().ReversGravity2();
            Destroy(gameObject);
        }

        else
        {
            reverseGravity.isReverse = false;
        }
    }
}
