using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneToLevel_1 : MonoBehaviour
{
    public GameObject LoadTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(LoadTimer, 3);

        if (GameObject.Find("LoadTimer") == null)
        {
            SceneManager.LoadScene("Level-1");
        }
    }
}
