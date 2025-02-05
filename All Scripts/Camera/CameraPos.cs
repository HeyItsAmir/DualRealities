using Unity.VisualScripting;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] Transform cameraStartPos;
    [SerializeField] GameObject camera;
    private void Start()
    {
        camera = Camera.main.gameObject;
        camera.transform.position = cameraStartPos.position;
    }
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}
