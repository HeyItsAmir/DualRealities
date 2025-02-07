using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player1Animation : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    
    public PlayerController controller;

    public float PlayerSpeed;
    public Animator animator;
    public P1 P1;
    // Start is called before the first frame update
    void Start()
    {
        P1 = GetComponent<P1>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpeed = P1.speed;
        
        animator.SetFloat("Speed", PlayerSpeed);

        if (controller.isShooting)
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        if (P1.CloseAttack)
        {
            animator.SetTrigger("CloseAttack");
        }

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
