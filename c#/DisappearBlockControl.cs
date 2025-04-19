using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBlockControl : MonoBehaviour
{
    public Material[] materials;
    public float duration = 1f;
    private new Renderer renderer;
    private Vector3 position;

    private void Awake()
    {
        position = transform.position;
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
        float  timer = 0f;
        int state = 1;
        while (state < materials.Length)//4
        {         
            renderer.sharedMaterial = materials[state];
            while (timer <= duration)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            timer = 0f;
            state++;
        }   
        transform.position += Vector3.right * 100;
        renderer.sharedMaterial = materials[0];
        Invoke("Rest", 2f);
    }
    public void Rest()
    {
        transform.position = position;
    }
}
