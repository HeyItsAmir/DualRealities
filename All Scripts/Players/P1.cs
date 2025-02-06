using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1 : MonoBehaviour
{
    private bool isGrounded;
    bool isReverse;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public float speed = 1.0f;
    [SerializeField] float jump = 10f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;
    public BackgroundLooper repeat;
    public float scrollspeed =0f;

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
        //nemizare Player is samt rast is camera kharej she
        float maxXposition = cameraTransform.position.x + rightLimitOfsset;

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
        if (Input.GetKey(KeyCode.S) && isGrounded) 
        {
            Debug.Log("crouch");
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
}
