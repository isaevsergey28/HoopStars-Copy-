using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : Movement
{
    [SerializeField] private Transform _centerDot;
    private Transform _botTransform;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _botTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if(_botTransform.position.y < _centerDot.position.y && Random.Range(0, 20) == 10)
        {
            if (_botTransform.position.x < _centerDot.position.x && Random.Range(0, 2) == 1)
            {
                base.SetRightImpulse(_rigidbody);
            }
            else if(_botTransform.position.x > _centerDot.position.x && Random.Range(0, 2) == 1)
            {
                base.SetLeftImpulse(_rigidbody);
            }
        }
       
    }
}
