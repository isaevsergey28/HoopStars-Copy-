using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    private readonly string[] COMPLIMENTS = { "EXCELLENT", "FANTASTIC", "WONDERFUL" };
    [SerializeField] private GameObject _complimentPrefab;
    [SerializeField] private Transform _complimentParent;

    [SerializeField] private GameObject _hitCheckerObject;
    private HitChecker _hitCheker;

    private Text _scoreText;
    private int _playerScore;

    private Animator _textAnimation;
    private void Start()
    {
        _hitCheker = _hitCheckerObject.GetComponent<HitChecker>();
        _textAnimation = GetComponent<Animator>();
        _scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        _playerScore = _hitCheker.PlayerScore;
        if(_scoreText.text != _playerScore.ToString())
        {
            StartCoroutine(SetAndNotify());
        }
    }
    public virtual IEnumerator SetAndNotify()
    {
        if(gameObject.name == "LeftScore")
        {
            ShowCompliment();
        }
        _scoreText.text = _playerScore.ToString();
        _textAnimation.enabled = true;
        yield return new WaitForSeconds(4f);
        _textAnimation.enabled = false;
    }
    private void ShowCompliment()
    {
        GameObject _tempComplimentObject;
        string text = COMPLIMENTS[Random.Range(0, 3)];
        _tempComplimentObject = Instantiate(_complimentPrefab, _complimentParent.position, Quaternion.identity, _complimentParent);
        _tempComplimentObject.transform.GetChild(0).GetComponent<Text>().text = text;
        Destroy(_tempComplimentObject, 4f);
    }
}
