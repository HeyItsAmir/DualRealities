using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public GameObject FullHealth;

    public Animator animator;

    private bool isGrounded;
    bool isReverse;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] float jump;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;
    public GameObject GameOverUI;
    public bool CloseAttack;
    public bool isDead;
    public GameObject Health1, Health2, Health3; 
    private int currentHealth = 3;

    public bool IsJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isReverse = GetComponent<ReverseGravity>().isReverse;
    }

    // Update is called once per frame
    void Update()
    {
        //nemizare Player az samt rast az camera kharej she
        float maxXposition = cameraTransform.position.x + rightLimitOfsset;
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                speed = 10f;
            }

            else
            {
                speed = 0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                PlayerMove(-1);
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxXposition)
            {
                PlayerMove(1);
            }

            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CloseAttack = true;
            }
            else
            {
                CloseAttack = false;
            }

        }
        else
        {
            speed = 0;
            jump = 0;
            //scrollspeed = 0; 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            IsJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            IsJumping = true;
        }
    }
    void PlayerMove(int direction)
    {
        Vector2 move = new Vector3(direction, 0) * speed * Time.deltaTime;
        transform.Translate(move);

        if (direction > 0)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-2, 2, 1);
        }
    }
    void Jump()
    {
        IsJumping = true;
        if (isReverse)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * -1);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
                if (collision.CompareTag("Enemy") )
          {
            
             if (currentHealth <= 0) return; 

        currentHealth--; 

        
        if (currentHealth == 2) Health1.SetActive(false);
        else if (currentHealth == 1) Health2.SetActive(false);
        else if (currentHealth == 0)
        {
            Health3.SetActive(false);
            Die(); 
        }
    }}
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetBool("Dead", true);
            StartCoroutine(DestroyAfterDeath());
        }
    }

    IEnumerator DestroyAfterDeath()
    {
        FullHealth.SetActive(false);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Time.timeScale = 0f;  
        GameOverUI.SetActive(true); 
    }
}
