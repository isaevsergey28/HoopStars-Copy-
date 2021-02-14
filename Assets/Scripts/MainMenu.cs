using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Slider _slider;

    public void StartGame(int sceneIndex)
    {
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }
    private IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);
        _button.gameObject.SetActive(false);
        _slider.gameObject.SetActive(true);
        while (!loadOperation.isDone)
        {
            float loadProgress = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _slider.value = loadProgress;
            yield return null;
        }
    }
}
