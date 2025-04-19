using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveContorl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.revivePoint = transform.position;
        }
    }
}
