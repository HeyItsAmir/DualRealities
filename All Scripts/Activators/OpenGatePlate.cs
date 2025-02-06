using Unity.VisualScripting;
using UnityEngine;

public class OpenGatePlate : MonoBehaviour
{
    [SerializeField]
    GameObject gate;
    public Animator animator;
    public Animator animatorbutton;
    void OnCollisionEnter2D(Collision2D collision)
    {
        animatorbutton.SetBool("Tr",true);
        if(collision.gameObject.tag == "Player")
        {
            Active();
        }
    }

    void Active()
    {
        //animation
        animator.SetBool("Tr",true);
    }
}
