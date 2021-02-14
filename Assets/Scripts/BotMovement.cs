using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BotMovement : Movement
{
    private Transform _centerDot;
    private Transform _botTransform;
    private Rigidbody _rigidbody;

    private SphereBehaviour _sphereBehaviour;
    
    [Inject]
    public void Construct(SphereBehaviour sphereBehaviour)
    {
        _sphereBehaviour = sphereBehaviour;
        _centerDot = _sphereBehaviour.botCenterDot.transform;
    }

    private void Start()
    {
        _botTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(_sphereBehaviour)
        {
            if (_botTransform.position.y < _centerDot.position.y && Random.Range(0, 25) == 10)
            {
                if (_botTransform.position.x < _centerDot.position.x && Random.Range(0, 2) == 1)
                {
                    base.SetRightImpulse(_rigidbody);
                }
                else if (_botTransform.position.x > _centerDot.position.x && Random.Range(0, 2) == 1)
                {
                    base.SetLeftImpulse(_rigidbody);
                }
            }
        }
       
    }
}
