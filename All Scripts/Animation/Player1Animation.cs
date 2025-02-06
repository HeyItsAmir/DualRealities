using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player1Animation : MonoBehaviour
{
    
    public float PlayerSpeed;
    public Animator animator;
    public P1 P1;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GetComponent<P1>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = P1.speed;
        
        animator.SetFloat("Speed", PlayerSpeed);

        if (P1.IsJumping)
        {
            animator.SetBool("MidAir", true);
        }
        else
        {
            animator.SetBool("MidAir", false);
        }
    }
}
