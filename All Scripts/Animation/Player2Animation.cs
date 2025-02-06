using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player2Animation : MonoBehaviour
{
    public float PlayerSpeed;
    public float PlayerSpeed2;
    public Animator animator;
    public P2 P2;
    public PlayerController2 P2c;
    // Start is called before the first frame update
    void Start()
    {
        P2 = GetComponent<P2>();
        P2c= GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = P2.speed;
        //PlayerSpeed2 = P2c.moveSpeed;

        animator.SetFloat("Speed", PlayerSpeed);
        //animator.SetFloat("Speed", PlayerSpeed2);
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
