using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public ReverseGravity Reverse;
    public ReverseGravity Reverse2;
    public Reverse2 aReverse;
    public Reverse2 aReverse2;
    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
         Reverse.enabled = !Reverse.enabled;
         Reverse2.enabled = !Reverse2.enabled;
         aReverse.enabled = !aReverse.enabled;
         aReverse2.enabled = !aReverse2.enabled;
    }
            
        
    
}
