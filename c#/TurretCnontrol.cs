using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public Transform fatherTransform;
    public Transform childrenTransform;
    public GameObject bullet;
    public float distance = 10f;
    public float durationTime = 1f;
    public float relOffest = 0f;
    public Vector3 direction { get; private set; }
    public Transform bulletPosition;

    public int hp =8;
    private Transform player;

    private Vector3 fRotate;
    private Vector3 cRotate;
    
    private float timer=0;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
       
    }
    private void FixedUpdate()
    {
        float relDistance = Distance();
        if (relDistance < distance )
        {
          
            timer += Time.fixedDeltaTime;
            float[] angle = Angle();
            fRotate = new Vector3(-90, 0, angle[1] + 90);
            cRotate = new Vector3(angle[0], 0, 0);

            childrenTransform.localRotation = Quaternion.Euler(cRotate);
            fatherTransform.rotation = Quaternion.Euler(fRotate);
            if (timer > durationTime)
            {
                Fire();
                timer = 0;
            }
        }
       
    }

    private float Distance()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    private float[] Angle()
    {
        
        direction = player.position - transform.position;
        Vector3 horDirection = new Vector3(direction.x, 0, direction.z)+relOffest*player.forward;
        float vertical = Vector3.Angle(Vector3.up, direction);
        float horizontal = Angle_360(Vector3.right, horDirection);
       // Debug.Log(vertical);
        return new float[2] { vertical, horizontal };
    }

    private float Angle_360(Vector3 from, Vector3 to)
    {
        Vector3 v3 = Vector3.Cross(from, to);
        if (v3.y > 0)
            return Vector3.Angle(from, to);
        else
            return 360 - Vector3.Angle(from, to);
    }

    private void Fire()
    {
        Instantiate(bullet,bulletPosition.position, childrenTransform.rotation);      
    }



    public void GetDamge()
    {
        hp--;
        if (hp == 0)
        {
            gameObject.SetActive(false);
        }              
    }

}
