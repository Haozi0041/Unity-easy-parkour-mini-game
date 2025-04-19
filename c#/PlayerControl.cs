using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed=3.5f;
    public float jumpForce=4f;
    public float power=5f;
    public GameObject bullet;
    public UIManager ui;
    private CameraControl camera;
    public bool isRunning { get; private set; }
    public bool isJumping { get; private set; }
    public bool isGround { get; private set; }

    private float horizontal;
    private float vertical;
    private Vector3 dir;
    private new Rigidbody rigidbody;
    private Animator Animator;
    private Vector3 velocity;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        //velocity = transform.position;
        isGround = true;
        Animator.SetBool("true", true);
        
    }

    private void Update()
    {
        transform.rotation = Camera.main.transform.parent.rotation;
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Ray ray = new Ray(transform.position, Vector3.down);
        dir = new Vector3(horizontal, 0, vertical);



        isRunning = dir == Vector3.zero ? false : true;
        
        if (Physics.Raycast(ray, 0.3f))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        Animator.SetBool("Run", isRunning);
        //Debug.Log(isGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGround ==true)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
        }

        if (ui.bulletNumber != 0 && Input.GetMouseButtonDown(0)) 
        {
           Instantiate(bullet, transform.position + transform.forward * 0.4f+Vector3.up *0.5f, transform.rotation);
           ui.RemoveItem();
        }
        
    }
    private void FixedUpdate()
    {
        Animator.SetBool("Jump", isJumping);

        transform.Translate(Vector3.forward * vertical * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * moveSpeed * 0.5f * Time.deltaTime);

        if (isJumping)
        {        
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

}
