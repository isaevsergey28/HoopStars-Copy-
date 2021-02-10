using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] protected float _jumpPower;
    [SerializeField] protected float _forceUp;
    [SerializeField] protected float _sideForce;

    public void SetLeftImpulse(Rigidbody rigidbody)
    {
        var vector = _jumpPower * new Vector3(-(_sideForce), _forceUp, 0);
        rigidbody.velocity = vector;
    }
    public void SetRightImpulse(Rigidbody rigidbody)
    {
        var vector = _jumpPower * new Vector3(_sideForce, _forceUp, 0);
        rigidbody.velocity = vector;
    }
}
