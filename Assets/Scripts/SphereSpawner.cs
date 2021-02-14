using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _allSpheres;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private GameObject _gameControllerObject;
    private GameController _gameControllerScript;

    private GameObject _tempSphereObject;
    private GameObject _currentSphere;

    private void Start()
    {
        _gameControllerScript = _gameControllerObject.GetComponent<GameController>();

        _currentSphere = _allSpheres[Random.Range(0, _allSpheres.Length)];
        SpawnSphere();
    }

    private void Update()
    {
        if(_gameControllerScript.IsGameOver)
        {
            DestroySphere();
        }
    }
    private void SpawnSphere()
    {
        _tempSphereObject = Instantiate(_currentSphere, _spawnPosition, Quaternion.identity, gameObject.transform);
    }
    private void DestroySphere()
    {
        Destroy(_tempSphereObject);
    }
}
