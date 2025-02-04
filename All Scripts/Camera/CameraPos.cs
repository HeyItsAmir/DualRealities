using Unity.VisualScripting;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] GameObject camera;

    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}
