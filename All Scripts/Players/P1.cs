using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    private bool isGrounded;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jump;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rightLimitOfsset = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    void PlayerMove(int direction)
    {
        Vector2 move = new Vector3(direction, 0) * speed * Time.deltaTime;
        transform.Translate(move);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
    }
}
