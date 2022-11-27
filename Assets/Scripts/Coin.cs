using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Movement leftRight;
    public Movement forward;
    public MouseInput _mouseInput;

    public Turn _turn;
    public Turn _turnLeftRight;

    private void Start()
    {
        leftRight.Start();
        forward.Start();
    }

    private void Update()
    {
        // leftRight.MoveLeftRight(_mouseInput.MoveFactorX, Time.deltaTime);
        forward.MoveFoward(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //_turn.SetTurnValue(_mouseInput.MoveFactorX).SetFrame(Time.fixedDeltaTime).Execute();
        _turnLeftRight.SetTurnValue(_mouseInput.MoveFactorX).SetFrame(Time.fixedDeltaTime).ExecuteY();
    }
}