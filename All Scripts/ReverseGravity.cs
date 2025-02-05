using UnityEngine;

public class ReverseGravity : MonoBehaviour
{
    public bool isReverse;
    void Start()
    {
        isReverse = false;
    }

    public void ReversGravity()
    {
        if(isReverse)
        {
            Physics2D.gravity = new Vector2(0, 12);
            transform.rotation = Quaternion.Euler(-180, 0, 0);
            isReverse = false;
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -12);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isReverse = true;
        }
    }
}