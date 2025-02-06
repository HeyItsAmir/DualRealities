using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject MusicManager; 

    void Start()
    {
        if (MusicManager != null)
        {
            MusicManager.SetActive(true);
        }
        else
        {
            Debug.LogError("MusicManager not assigned in Level-1!");
        }
    }
}
