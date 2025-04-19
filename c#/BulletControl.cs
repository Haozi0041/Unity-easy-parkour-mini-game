using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float moveSpeed = 5f;
   
    private void Awake()
    {
        
        Destroy(gameObject, 3f);
    }
    

    private void Update()
    {
        RaycastHit hit;
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.2f))
        {
            Debug.Log("hit");
            if (hit.transform.CompareTag("Player"))
            {
                hit.transform.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.Impulse);
            }
            else if (hit.transform.CompareTag("Turret"))
            {
                hit.transform.GetComponent<TurretControl>().GetDamge();              
            }
            Destroy(gameObject);
        }           
    }
}
