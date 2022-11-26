using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collectable"))
        {
            other.transform.SetParent(transform.parent);
            other.transform.tag = "Collected";
            Vector3 newPos = transform.parent.GetChild(1).transform.localPosition;
            other.transform.localPosition =
                new Vector3(0, newPos.y, newPos.z + (transform.parent.childCount - 2) * -0.4f);
            other.AddComponent<Follow>();
           
        }
    }
}