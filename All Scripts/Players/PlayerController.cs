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

    void Update()
    {
        // char movement
        // float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // transform.Translate(new Vector2(moveX, moveY));

        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        // bullet 
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}