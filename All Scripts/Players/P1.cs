using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P1 : MonoBehaviour
{
    private bool isGrounded;
    bool isReverse;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jump = 10f;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;
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

        if (Input.GetKey(KeyCode.A))
        {
            PlayerMove(-1);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxXposition)
        {
            PlayerMove(1);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    void PlayerMove(int direction)
    {
        Vector2 move = new Vector3(direction, 0) * speed * Time.deltaTime;
        transform.Translate(move);
    }
    void Jump()
    {      
        if(isReverse)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump * -1);
        }
        else
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }
    }
}
