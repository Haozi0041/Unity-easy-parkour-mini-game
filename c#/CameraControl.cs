using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    Transform player;
    public float Sne = 120;
    public float cameraOffest = 2.5f;
    public float distance = 0.05f;



    private float xMouse;
    private float yMouse;
    private float xMouseRotation;
    private float yMouseRotation;
    private float dir;
    private UIManager uIManager;
    public bool isEnough { get; private set; }
    public float hitDistance { get; private set; }
    public Vector3 hitPosition { get; private set; }
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.position = player.transform.position;
        dir = Vector3.Distance(Camera.main.transform.position ,transform.position);
        uIManager = GameObject.FindWithTag("UI").GetComponent<UIManager>();
    }

    private void Update()
    {
        transform.position = player.position + Vector3.up * cameraOffest;

        xMouseRotation += Input.GetAxis("Mouse X") * Sne * Time.deltaTime;
        yMouseRotation -= Input.GetAxis("Mouse Y") * Sne * Time.deltaTime;
        xMouse = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, xMouse * Sne * Time.deltaTime);
        Quaternion rotation = Quaternion.Euler(yMouseRotation, xMouseRotation, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -dir);
        Camera.main.transform.position = transform.position + offset;
        Camera.main.transform.LookAt(transform.position);



        RaycastHit hit;
        Ray ray = new Ray(player.transform.position, RayCacul());
        if (Physics.Raycast(ray, out hit))
        {
            hitDistance = Vector3.Distance(transform.position, hit.transform.position);
            isEnough = (hit.transform.CompareTag("Bullets") && hitDistance < 2f) ? true : false;
            hitPosition = hit.point;
            if (Input.GetKeyDown(KeyCode.F) && isEnough && uIManager.bulletNumber < uIManager.maxBullets)
            {
                hit.transform.GetComponent<PlayerBullet>().MyDestory();
                uIManager.AddItem();
            }
            //Debug.Log(isEnough);
            Debug.DrawRay(player.transform.position, Camera.main.transform.forward);
        }
        uIManager.AddCircleState(isEnough);

        
    }

   


    public Vector3 RayCacul()
    {
        Ray camera = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit cam;
        if (Physics.Raycast(camera, out cam))
        {
            return cam.point - player.transform.position;
        }
        else
        {
            return Vector3 .zero;
        }
    }

   
}
