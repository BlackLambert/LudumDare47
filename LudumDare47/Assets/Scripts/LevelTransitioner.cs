using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{
    [SerializeField]
    private LoadingScreen _screen = null;

    public void Transition(string currentScene, string nextScene)
	{
        StartCoroutine(doTransition(currentScene, nextScene));
	}

    private IEnumerator doTransition(string currentScene, string nextScene)
    {
        _screen.Display();
        yield return new WaitForSeconds(0.33f);
        AsyncOperation operation = SceneManager.UnloadSceneAsync(currentScene);
        while (!operation.isDone)
            yield return new WaitForSeconds(0);
        operation = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        while (!operation.isDone)
            yield return new WaitForSeconds(0);
        _screen.Hide();
    }
}
