using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public GameObject FullHealth;
    private MusicRandomPlay musicRandomPlay;
    public Animator animator;

    private bool isGrounded;
    public bool isReverse;
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
    public float scrollspeed;

    public P1 p1;

    public bool IsJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GetComponent<P1>();
        rb = GetComponent<Rigidbody2D>();
        musicRandomPlay = FindObjectOfType<MusicRandomPlay>();
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
                scrollspeed = 0f;
                speed = 0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                scrollspeed = -4f;
                PlayerMove(-1);
            }

            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < maxXposition)
            {
                scrollspeed = 4f;
                PlayerMove(1);
            }

            if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
            {
                scrollspeed = 0f;
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                scrollspeed = 0f;
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
            scrollspeed = 0f; 
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
            transform.localScale = new Vector3(2, transform.localScale.y, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-2, transform.localScale.y, 1);
        }
    }
    void Jump()
    {
        IsJumping = true;
        if (isReverse)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * -1);
            transform.localScale = new Vector3(transform.localScale.x, 2, transform.localScale.z);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
     void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.CompareTag("Enemy"))
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
        }
     }
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
        musicRandomPlay.audioSource.Pause();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        Time.timeScale = 0f;  
        GameOverUI.SetActive(true); 
    }
}
