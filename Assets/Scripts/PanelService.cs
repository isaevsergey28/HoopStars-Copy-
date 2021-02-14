using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelService : MonoBehaviour
{
    [SerializeField] private Text _resultText;

    private void Start()
    {
        if (GameController.instance.IsPlayerWon)
        {
            _resultText.text = "You won!";
        }
        else
        {
            _resultText.text = "You lose!";
        }
    }

    public void StartMainMenu(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }
    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
