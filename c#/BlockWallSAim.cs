using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWallSAim : MonoBehaviour
{
    public Material[] materials;
    public bool isTheAim;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        isTheAim = false;
        renderer.sharedMaterial = materials[0];
    }
    private void Update()
    {
        if (isTheAim)
        {
            renderer.sharedMaterial = materials[1];
        }
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsRight();
            
        }

    }

    private void IsRight()
    {
        if (isTheAim)
        {
            GetComponentInParent<BlockWall>().Down();
            isTheAim = false;
            renderer.sharedMaterial = materials[0];
        }
    }
}
