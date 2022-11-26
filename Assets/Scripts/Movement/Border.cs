using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Border 
{
    private Vector3 pos;
    private Transform moveObject;
    public float max;
    public float min;


    public void SetMoveObject(Transform moveObject)
    {
        this.moveObject = moveObject;
    }
    public void RunBorder()
    {
        pos = moveObject.position;
        pos.x = Mathf.Clamp(pos.x, min, max);
        moveObject.position = pos;
    }
}