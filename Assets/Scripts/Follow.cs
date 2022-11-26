using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform followThis;
    public Transform followMain;
    private Vector3 followObject;

    public float angleSpeed = 5f;
    public float posSpeed = 15f;

    private void Start()
    {
        followThis = transform.parent.GetChild(transform.GetSiblingIndex() - 1);
        followMain = transform.parent.GetChild(1);
    }

    private void Update()
    {
        FollowObject();
        //follow this position lerp
        transform.localPosition = Vector3.Lerp(transform.localPosition, followObject, Time.deltaTime * posSpeed);
        //follow this rotation lerp
        //transform.LookAt(followThis);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, followThis.localRotation, Time.deltaTime * angleSpeed);
    }

    void FollowObject()
    {
        followObject = followThis.localPosition;
        followObject.z = transform.localPosition.z;
    }
}