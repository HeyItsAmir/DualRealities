using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ChaserMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector3(1, 0) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}
