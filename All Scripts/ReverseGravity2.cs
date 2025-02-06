using UnityEngine;

public class ReverseGravity2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    void Update()
    {
        Physics2D.gravity = new Vector2(0, 9.81f);
        transform.rotation = Quaternion.Euler(0, -180, 180);
    }


}