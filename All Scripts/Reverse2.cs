using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    void Update()
    {
        Physics2D.gravity = new Vector2(0, -12f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
