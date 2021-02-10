﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    private Rigidbody _rigidbody;
 
    private void Start()
    {
        Time.timeScale = 3f;
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void SetLeftImpulse()
    {
        base.SetLeftImpulse(_rigidbody);

    }
    public void SetRightImpulse()
    {
        base.SetRightImpulse(_rigidbody);
    }
}