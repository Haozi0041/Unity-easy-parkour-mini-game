using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BoomStation : MonoBehaviour
{
    public GameObject boom;

    public float interval = 2.5f;
    float timer = 0f;
    
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0-Random.Range(0,0.5f);
            Instantiate(boom, transform.position + Vector3.forward * 0.5f, Quaternion.identity);
        }        
    }
}
