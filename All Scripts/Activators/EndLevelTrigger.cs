using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Chaser")
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Main_Menu");
        }
    }

}
