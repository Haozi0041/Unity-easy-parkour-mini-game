using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour
{
    public BlockWallSAim[] Aims;
    public int number { get; private set; }

    private Vector3 position;
    private void Awake()
    {
        Aims = GetComponentsInChildren<BlockWallSAim>();
        position = transform.position;
    }
    private void Start()
    {
        RandomAim();
    }

    public void Down()
    {
        transform.position += Vector3.down * 20;
        Invoke("Rest",2f);
    }

    private void Rest()
    {
        transform.position = position;
        RandomAim();
    }

    private void RandomAim()
    {
        number = Random.Range(0, 3);
        Aims[number].isTheAim = true;
    }
}
