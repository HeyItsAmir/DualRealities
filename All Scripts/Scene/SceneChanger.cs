using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private MusicRandomPlay musicRandomPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        musicRandomPlay = FindObjectOfType<MusicRandomPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTheSceneToLevel1()
    {
        Debug.Log("Changing");
        SceneManager.LoadScene("Level-1");
    }
    public void ChangeTheSceneToMainMenu()
    {
        
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main_Menu");
    }
    public void ChangeTheSceneToCredit()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void ChangeToTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    public void ChangeToLoadingScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}
