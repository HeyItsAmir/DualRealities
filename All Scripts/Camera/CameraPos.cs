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
        background.transform.position = new Vector3(transform.position.x , -2.4f, 5f);
        background2.transform.position = new Vector3(transform.position.x , 2.5f, 5f);//change beshe bar asas mohal background ha 
    }
}
