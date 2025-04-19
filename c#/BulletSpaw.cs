using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpaw : MonoBehaviour
{
    public GameObject bullet;
    public float Space = 14f;
    private float timer = 0;
    private void Awake()
    {
        Spaw();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > Space)
        {
            Spaw();
            timer = 0;
        }
    }
    private void Spaw()
    {
        Vector3 position = new Vector3(Random.Range(0, 2f), 0, Random.Range(0, 2f));
        Instantiate(bullet, transform.position + position, Quaternion.identity);
        //Debug.Log(position);
    }
}
