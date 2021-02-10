using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    private int _countInactiveDots = 0;
    private int _triggerToIncScore = 4;

    public int PlayerScore { get; private set; } = 0;

    private float _distanceToActiveDots = 5.0f;

    public GameObject[] allSphereDots;
    public GameObject centerSphereDot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SphereDot" && other.gameObject.activeSelf)
        {
            _countInactiveDots++;
            other.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        _countInactiveDots = Mathf.Clamp(_countInactiveDots, 0, _triggerToIncScore);
        if (_countInactiveDots == _triggerToIncScore)
        {
            _countInactiveDots = 0;
            PlayerScore++;
        }
        if(Vector3.Distance(gameObject.transform.position, centerSphereDot.transform.position) > _distanceToActiveDots)
        {
            SetAllDotsActive();
        }
    }
    private void SetAllDotsActive()
    {
        foreach (GameObject sphereDot in allSphereDots)
        {
            sphereDot.SetActive(true);
        }
    }
}
