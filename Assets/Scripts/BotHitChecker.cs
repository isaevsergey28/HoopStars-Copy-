using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BotHitChecker : HitChecker
{
    private GameObject[] _allSphereDots;
    private GameObject _centerSphereDot;
    private SphereBehaviour _sphereBehaviour;

    [Inject]
    public void Construct(SphereBehaviour sphereBehaviour)
    {
        _sphereBehaviour = sphereBehaviour;
        _allSphereDots = _sphereBehaviour.botSphereDots;
        _centerSphereDot = _sphereBehaviour.botCenterDot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BotDot" && other.gameObject.activeSelf)
        {
            DisableDot(other);
        }
    }
    private void Update()
    {
        CheckDots(_allSphereDots, _centerSphereDot, _sphereBehaviour);
    }
}
