using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotHitChecker : HitChecker
{
    public GameObject[] allSphereDots;
    public GameObject centerSphereDot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BotDot" && other.gameObject.activeSelf)
        {
            DisableDot(other);
        }
    }
    private void Update()
    {
        CheckDots(allSphereDots, centerSphereDot);
    }
}
