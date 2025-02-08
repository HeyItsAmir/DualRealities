using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class P1 : MonoBehaviour
{
    public GameObject FullHealth;
    private MusicRandomPlay musicRandomPlay;
    public Animator animator;

    private bool isGrounded;
    public bool isReverse;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] float jump = 10f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;
    public BackgroundLooper repeat;
    public float scrollspeed =0f;
    private float lastXPosition;
    public GameObject GameOverUI;

    public P2 p2;

    public bool CloseAttack;
    public bool isDead;
    public bool IsJumping = false;
        public GameObject Health1, Health2, Health3; 
        private int currentHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        p2 = GetComponent<P2>();
        musicRandomPlay = FindObjectOfType<MusicRandomPlay>();
        rb = GetComponent<Rigidbody2D>();
        lastXPosition = transform.position.x;
        isReverse = GetComponent<ReverseGravity>().isReverse;
    }

    // Update is called once per frame
    void Update()
    {


        //nemizare Player is samt rast is camera kharej she
        float maxXposition = cameraTransform.position.x + rightLimitOfsset;
        if (!isDead)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                speed = 10f;

            }

            else
            {
                speed = 0f;
                scrollspeed = 0;
            }

            if (Input.GetKey(KeyCode.A))
            {
                PlayerMove(-1);
                scrollspeed = -5;
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x < maxXposition)
            {
                PlayerMove(1);
                scrollspeed = 5;
            }
            if (Input.GetKey(KeyCode.W) && isGrounded)
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                CloseAttack = true;
            }
            else
            {
                CloseAttack = false;
            }
            if (transform.position.x > lastXPosition)
            {
                ScoreManager.instance.AddScore(1);
                lastXPosition = transform.position.x;
            }
        }
        else
        {
            speed = 0;
            jump = 0;
            scrollspeed = 0;
        }
    }
    
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            IsJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
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
        if(isReverse)
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
                animator.SetBool("Dead", true); 
                Invoke("Die", 2f);
         }
        }
    }
    public void Die()
    {   
        if (!isDead)
        {
            isDead = true;
            musicRandomPlay.audioSource.Pause();
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
            
    }
}
