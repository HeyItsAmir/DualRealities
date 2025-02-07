using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /*
    *READDDD MEEEEEE*
    FirePoint = Jaye ke azash shelik mishe golole va spawn mishe (ye empty game object joloye gun)
    Add a layer (Bullet) and change the bullet gameobject layer to Bullet
    Select the bullet layer in the unity
    You can use tag if you want but you have to change the code :\Enemy.cs Line 23
    Change Health-Damage-Lifetime-Bullet force and speed how you want 
    Add Enemy Script to enemys and PlayerController to player 
    Add Rigidbody2d with gravity scale 0 to bullet and collider2d with trigger on to Bullet
    Add Rigidbody2d with gravity scale 0 to bullet and collider2d with trigger on to Enemy 
    Omidvaram hamasho neveshte bashad xD
    */
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public float Lifetime = 2f;

    public bool isShooting = false;

    public float shootCD = 0.3f;

    private float shootTime, shootTimeStamp;

    void Update()
    {
        isShooting = false;
        // char movement
        // float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // transform.Translate(new Vector2(moveX, moveY));
        shootTimeStamp = Time.time;

        if (Input.GetKey(KeyCode.LeftControl) && shootTimeStamp > shootTime)
        {
            isShooting = true;
            Shoot();
            shootTime = shootTimeStamp + shootCD;
        }
       
    }


    public void Shoot()
    {
        // bullet 
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}