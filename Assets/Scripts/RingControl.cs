using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingControl : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _forceUp;
    [SerializeField] private float _sideForce;
    private void Start()
    {
        Time.timeScale = 3f;
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void SetLeftImpulse()
    {
        var vector = _jumpPower * new Vector3(-(_sideForce), _forceUp, 0);
        _rigidbody.velocity = vector;
    }
    public void SetRightImpulse()
    {
        var vector = _jumpPower * new Vector3(_sideForce, _forceUp, 0);
        _rigidbody.velocity = vector;
    }
}
