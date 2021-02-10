using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    private readonly string[] COMPLIMENTS = { "EXCELLENT", "FANTASTIC", "WONDERFUL" };
    [SerializeField] private GameObject complimentObject;
    [SerializeField] private Transform complimentTransform;

    [SerializeField] private GameObject hitCheckerObject;
    private HitChecker _hitCheker;

    private Text _scoreText;
    private int playerScore;

    private Animator _textAnimation;
    private void Start()
    {
        _hitCheker = hitCheckerObject.GetComponent<HitChecker>();
        _textAnimation = GetComponent<Animator>();
        _scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        playerScore = _hitCheker.PlayerScore;
        if(_scoreText.text != playerScore.ToString())
        {
            StartCoroutine(SetAndNotify());
        }
    }
    private IEnumerator SetAndNotify()
    {
        
        ShowCompliment();
        _scoreText.text = playerScore.ToString();
        _textAnimation.enabled = true;
        yield return new WaitForSeconds(4f);
        _textAnimation.enabled = false;
    }
    private void ShowCompliment()
    {
        GameObject _tempComplimentObject;
        string text = COMPLIMENTS[Random.Range(0, 3)];
        _tempComplimentObject = Instantiate(complimentObject, complimentTransform.position, Quaternion.identity, complimentTransform);
        _tempComplimentObject.transform.GetChild(0).GetComponent<Text>().text = text;
        Destroy(_tempComplimentObject, 4f);
    }
}
