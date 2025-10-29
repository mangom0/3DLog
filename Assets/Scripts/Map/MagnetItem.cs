using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            ExpItem[] allExpItems = FindObjectsOfType<ExpItem>(); // ��� ExpItem ã�� 

            foreach (ExpItem exp in allExpItems)
            {
                exp.ActivateGlobalMagnet();
            }

            Destroy(gameObject);
        }
    }
}