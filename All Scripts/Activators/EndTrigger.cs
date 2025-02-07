using Unity.VisualScripting;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb1, rb2;
    [SerializeField] Transform camerapos, p1pos, p2pos;
    [SerializeField] GameObject maincam, chasercamera, chaser;
    bool run = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //player pos set
            rb1.gameObject.transform.position = p1pos.position;

            rb2.gameObject.transform.position = p2pos.position;

            //camera pos set
            Destroy(chasercamera);
            maincam.transform.position = camerapos.position;

            //chaser speed
            chaser.GetComponent<ChaserMovement>().speed = 10f;

            //player running
            run = true;
        }
    }

    void Update()
    {
        if(run)
        {
            Vector2 move = new Vector3(1, 0) * 10 * Time.deltaTime;
            rb1.transform.Translate(move);
            rb2.transform.Translate(move);
        }
    }
}
