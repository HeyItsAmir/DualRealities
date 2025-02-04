using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    private bool isGrounded;
    public Rigidbody2D rb;
    public float speed = 1.0f;
    public float jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMove(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMove(1);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
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
        rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
    }
}
