using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 2f;
    public float scrollspeed = 0f;
    public GameObject GameOverUI;
    public bool isDead;

    private Vector2 moveInput;
    private Vector2 lookInput;
    public Rigidbody2D rb;
    private bool isGrounded = false;
    float direction;
    private float lastXPosition;
    public Animator animator;

    public bool isShooting;

    public float shootCD = 0.3f;

    private float shootTime, shootTimeStamp;
            public GameObject Health1, Health2, Health3; 
        private int currentHealth = 3;
void  Start()
{
    lastXPosition = transform.position.x;
}
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         if (transform.position.x > lastXPosition)
        {
            ScoreManager.instance.AddScore(1); 
            lastXPosition = transform.position.x;
        }
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        //if (groundCollider != null)
        //{
        //    Debug.Log("Ground detected: " + groundCollider.gameObject.name);
        //}
        //else
        //{
        //    Debug.Log("No ground detected!");
        //    Debug.Log("Is Grounded: " + isGrounded);
        //    Debug.Log("Ground Layer: " + groundLayer.value);
        //}

        //if (lookInput.magnitude > 0.1f)
        //{
        //    float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
        //    firePoint.rotation = Quaternion.Euler(0, 0, angle);
        //}
        shootTimeStamp = Time.time;

        if (Input.GetKey(KeyCode.RightControl) && shootTimeStamp > shootTime)
        {
            isShooting = true;
            Shoot();
            shootTime = shootTimeStamp + shootCD;
        }

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
        
        
         moveInput = context.ReadValue<Vector2>();
        if (moveInput.x < 0f)
         scrollspeed = -5f;
        else
         if(moveInput.x > 0f)
            scrollspeed = 5f;
        if (moveInput.magnitude < 0.1f) 
        {
          moveSpeed = 0f; 
          scrollspeed = 0f;
        }
        else
        {
         moveSpeed = 10f; 
         
        }
        
       
    }
   void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
   }
   void OnCollisionExit2D(Collision2D collision)
   {
    if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
   }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        moveSpeed=0f;
        if (context.performed && isGrounded == true)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    }
    

    public void OnFire(InputAction.CallbackContext context)
    {
        Shoot();
        if (context.performed)
        {
            isShooting = true;
            Shoot();
        }
        else
        {
            isShooting = false;
        }
    }

    private void FixedUpdate()
    {
        if (moveInput.x > 0) 
        {
            direction = 1;
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (moveInput.x < 0) 
        {
            direction = -1;
            transform.localScale = new Vector3(-2, 2, 2);
        }
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(bulletSpeed * -direction, rb.velocity.y);

       // rb.velocity = Vector2.right * bulletSpeed;

        
        Destroy(bullet, bulletLifetime);
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
        
 //       FullHealth.SetActive(false);
        
        if (!isDead)
        {
        isDead = true;
        GameOverUI.SetActive(true); 
        Time.timeScale = 0f; 
        Destroy(gameObject);
        }
            
    }
    }
