using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLooper : MonoBehaviour
{
    
    public P1 p1;
    
    public float scrollspeed;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    public void Update()
    {
        scrollspeed = p1.scrollspeed;
        offset += (Time.deltaTime * scrollspeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2 (offset, 0));
    }
}
