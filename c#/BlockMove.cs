using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float distance = 3f;

    private Vector3 position;
    private Vector3 newPosition;
    private Vector3 nowDirection;
    private void Awake()
    {
        position = transform.position;
        nowDirection = direction;
    }



    private void FixedUpdate()
    {
        newPosition = position + direction * distance;
        transform.Translate(direction * Time.deltaTime);
        if (Vector3.Distance(transform.position, newPosition) < 0.01f)
        {
            transform.position = newPosition;
            direction = -direction;
        }
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
