using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HitChecker : MonoBehaviour
{

    protected int _countInactiveDots = 0;
    protected int _triggerToIncScore = 5;

    public int Score { get; set; } = 0;

    protected float _distanceToActiveDots = 7.0f;



    protected void DisableDot(Collider other)
    {
        _countInactiveDots++;
        other.gameObject.SetActive(false);
    }

    protected void CheckDots(GameObject[] allSphereDots, GameObject centerSphereDot, SphereBehaviour sphereBehaviour)
    {
        if(sphereBehaviour)
        {
            _countInactiveDots = Mathf.Clamp(_countInactiveDots, 0, _triggerToIncScore);
            if (_countInactiveDots == _triggerToIncScore)
            {
                _countInactiveDots = 0;
                Score++;
            }
            if (Vector3.Distance(gameObject.transform.position, centerSphereDot.transform.position) > _distanceToActiveDots)
            {
                SetAllDotsActive(allSphereDots);
            }
        }
        
    }
    protected void SetAllDotsActive(GameObject[] allSphereDots)
    {
        
        foreach (GameObject sphereDot in allSphereDots)
        {
            sphereDot.SetActive(true);
        }
    }
}

