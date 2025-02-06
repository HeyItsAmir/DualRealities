using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    public float PlayerSpeed;
    public Animator animator;
    public P2 P2;
    // Start is called before the first frame update
    void Start()
    {
        P2 = GetComponent<P2>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = P2.speed;
        
        animator.SetFloat("Speed", PlayerSpeed);

        if (P2.IsJumping)
        {
            animator.SetBool("MidAir", true);
        }
        else
        {
            animator.SetBool("MidAir", false);
        }
    }
}
