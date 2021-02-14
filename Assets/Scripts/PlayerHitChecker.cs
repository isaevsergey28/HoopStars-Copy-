using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerHitChecker : HitChecker
{
    private GameObject[] _allSphereDots;
    private GameObject _centerSphereDot;
    private SphereBehaviour _sphereBehaviour;


    [Inject]
    public void Construct(SphereBehaviour sphereBehaviour)
    {
        _sphereBehaviour = sphereBehaviour;
        _allSphereDots = _sphereBehaviour.playerSphereDots;
        _centerSphereDot = _sphereBehaviour.playerCenterDot;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerDot" && other.gameObject.activeSelf)
        {
            DisableDot(other);
        }
    }
    private void Update()
    {
        CheckDots(_allSphereDots, _centerSphereDot, _sphereBehaviour);
    }
}
