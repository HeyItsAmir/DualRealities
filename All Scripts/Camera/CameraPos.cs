using Unity.VisualScripting;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] Transform cameraStartPos;
    [SerializeField] GameObject camera;
    [SerializeField] GameObject background;
    [SerializeField] Transform backgroundStartPos;
    [SerializeField] GameObject background2;
    [SerializeField] Transform backgroundStartPos2;
    private void Start()
    {
        camera = Camera.main.gameObject;
        camera.transform.position = cameraStartPos.position;
        background.transform.position = backgroundStartPos.position;
        background2.transform.position = backgroundStartPos2.position;
    }
    void Update()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
        background.transform.position = new Vector3(transform.position.x - 3.95f, 2.4976f, background.transform.position.z);
        background2.transform.position = new Vector3(transform.position.x + 3.95f, 2.4976f, background2.transform.position.z);//change beshe bar asas mohal background ha 
    }
}
