using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Movement
{

    [Tooltip("Hareket etmesini istediginiz objeyi yerlestiriniz")]
    public Transform moveObject;
    public float moveSpeed;
    public Border border;

    public void Start()
    {
        border.SetMoveObject(moveObject);
    }
    public void MoveFoward(float frame)
    {
        MoveCharacter(Vector3.forward,frame);
    }

    public void MoveCharacter(Vector3 direction ,float frame)
    {
        moveObject.Translate(direction * moveSpeed * frame);
    }
    public void MoveLeftRight(float distance,float frame)
    {

        moveObject.position += Vector3.right * distance * frame*moveSpeed;
        border.RunBorder();
    }


}