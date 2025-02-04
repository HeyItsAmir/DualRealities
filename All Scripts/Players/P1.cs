using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1 : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerMove(-1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerMove(1);
        }
        if (Input.GetKey(KeyCode.W) && isGrounded)
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
