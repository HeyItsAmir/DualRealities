using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    private bool isGrounded;
    bool isReverse;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] float jump;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;

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
        
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded)
        {
            Debug.Log("crouch");
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
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * -1);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }
    }
}
