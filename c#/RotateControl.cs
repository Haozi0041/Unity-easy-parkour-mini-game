using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
    public Transform center;
    public Vector3 aix;
    public float speed = 2f;

    private float distance;
    

    private void Awake()
    {
        distance = Vector3.Distance(transform.position, center.position);
        aix = aix.normalized;
    }

    private void FixedUpdate()
    {
        Vector3 front = (transform.position - center.position).normalized;
        Vector3 velocity = Vector3.Cross(aix, front).normalized;
        transform.Translate(velocity * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //Debug.Log("sss");
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }

}
