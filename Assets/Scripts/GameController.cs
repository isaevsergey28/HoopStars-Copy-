using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    public bool IsGameOver { get; private set; } = false;
    public bool IsPlayerWon { get; private set; }
    private Animator _shakeAnim;

    [SerializeField] private GameObject _hitPlayerObject;
    private PlayerHitChecker _hitPlayerChecker;

    [SerializeField] private GameObject _hitBotObject;
    private BotHitChecker _hitBotChecker;

    private int _tempScore = 0;
    [SerializeField] private int _winningScore;

    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        Time.timeScale = 3f;
        _shakeAnim = GetComponent<Animator>();
        _hitPlayerChecker = _hitPlayerObject.GetComponent<PlayerHitChecker>();
        _hitBotChecker = _hitBotObject.GetComponent<BotHitChecker>();
    }

    private void Update()
    {
        if (_hitPlayerChecker.Score != _tempScore)
        {
            StartCoroutine(Shake());
            _tempScore++;
        }
        if (_hitPlayerChecker.Score == _winningScore || _hitBotChecker.Score == _winningScore)
        {
            if(_hitPlayerChecker.Score == 5)
            {
                IsPlayerWon = true;
            }
            else
            {
                IsPlayerWon = false;
            }
            StartCoroutine(SlowDownTime());
            FinishGame();
        }
    }

    private void FinishGame()
    {
        _hitBotObject.transform.parent.GetComponent<BotMovement>().enabled = false;

        _leftButton.GetComponent<Button>().enabled = false;
        _rightButton.GetComponent<Button>().enabled = false;
        _gameOverPanel.SetActive(true);
        IsGameOver = true;
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
