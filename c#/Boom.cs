using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float force = 15;
    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward*force,ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 8f, ForceMode.Impulse);
        }
    }
}
