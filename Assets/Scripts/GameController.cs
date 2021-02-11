using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Animator _shakeAnim;

    [SerializeField] private GameObject _hitObject;
    private PlayerHitChecker _hitChecker;

    private int _tempScore = 0;

    private void Start()
    {
        Time.timeScale = 3f;
        _shakeAnim = GetComponent<Animator>();
        _hitChecker = _hitObject.GetComponent<PlayerHitChecker>();
    }

    private void Update()
    {
        if (_hitChecker.Score != _tempScore)
        {
            StartCoroutine(Shake());
            _tempScore++;
        }
        if (_hitChecker.Score == 5)
        {
            StartCoroutine(SlowDownTime());
        }
    }
    private IEnumerator SlowDownTime()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 3f;
    }
    public IEnumerator Shake()
    {
        _shakeAnim.SetBool("isGoal", true);
        yield return new WaitForSeconds(1f);
        _shakeAnim.SetBool("isGoal", false);
    }
}
