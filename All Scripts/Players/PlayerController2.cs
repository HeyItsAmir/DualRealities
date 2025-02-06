using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float bulletLifetime = 2f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer & ~(1 << gameObject.layer));

        if (lookInput.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(lookInput.y, lookInput.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    }
    

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    private void Shoot()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        
        bulletRb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        
        Destroy(bullet, bulletLifetime);
    }
    }
