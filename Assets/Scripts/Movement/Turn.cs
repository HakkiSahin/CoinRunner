using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Turn
{
    public Transform turnObject;
    public float turnSpeed;

    [Header("Border")] public float maxAngle;
    public float minAngle;


    private float frame;
    private float value;

    public Turn SetTurnValue(float value)
    {
        if (value > 0)
        {
            value = maxAngle;
        }
        else if (value < 0)
        {
            value = minAngle;
        }

        this.value = value;
        return this;
    }

    public Turn SetFrame(float frame)
    {
        this.frame = frame;
        return this;
    }

    public void Execute()
    {
        turnObject.rotation =
            Quaternion.Lerp(turnObject.rotation,
                Quaternion.Euler(turnObject.rotation.eulerAngles.x, value, 0), frame * turnSpeed);
    }

    public void ExecuteY()
    {
        turnObject.rotation = Quaternion.Lerp(turnObject.rotation,
            Quaternion.Euler(turnObject.rotation.eulerAngles.x, value, 0), frame * turnSpeed);
    }
}