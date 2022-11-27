using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform followThis;
    public Transform followMain;

    public float angleSpeed = 10f;
    public float posSpeed = 5f;

    
    private void Start()
    {
        followThis = transform.parent.GetChild(transform.GetSiblingIndex() - 1);
        followMain = transform.parent.GetChild(1);
    }

    private void Update()
    {
        //follow this position lerp
        transform.localPosition =
            Vector3.Lerp(transform.localPosition, followThis.localPosition, Time.deltaTime * posSpeed);
        //follow this rotation lerp

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation, followThis.localRotation, Time.deltaTime * angleSpeed);
    }
}