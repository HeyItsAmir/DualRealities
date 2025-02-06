using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTheSceneToLevel1()
    { 
        SceneManager.LoadScene("Level-1");
    }
    public void ChangeTheSceneToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main_Menu");
    }
}
