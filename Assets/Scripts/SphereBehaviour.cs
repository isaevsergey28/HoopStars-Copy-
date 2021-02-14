using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SphereBehaviour : MonoBehaviour
{
    public GameObject[] playerSphereDots;
    public GameObject playerCenterDot;
    public GameObject[] botSphereDots;
    public GameObject botCenterDot;

    [SerializeField] private Vector3 _startPos;
    [SerializeField] private GameObject _explosionPrefab;

    private void Update()
    {
        if (transform.position != _startPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos, Time.deltaTime);
        }
        if(GameController.instance.IsGameOver)
        {
            Destroy(this.gameObject);
            GameObject explosionTemp = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosionTemp, 2f);
            
        }
    }
}
