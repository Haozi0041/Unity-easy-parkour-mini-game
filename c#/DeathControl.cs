using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Succ");
            //DeathAnima();
            //Destroy(other);
            GameManager.Instance.Revive();
        }
    }
}
