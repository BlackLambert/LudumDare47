using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitioner : MonoBehaviour
{
    [SerializeField]
    private LoadingScreen _screen = null;

    public void Transition(List<string> scenesToUnload, List<string> scenesToLoad)
	{
        FindObjectOfType<Coroutiner>().StartCoroutine(doTransition(scenesToUnload, scenesToLoad));
	}

    private IEnumerator doTransition(List<string> scenesToUnload, List<string> scenesToLoad)
    {
        _screen.Display();
        yield return new WaitForSeconds(0.33f);
        AsyncOperation operation = null;
        foreach (string scene in scenesToUnload)
        {
            Debug.Log(scene);
            operation = SceneManager.UnloadSceneAsync(scene);
            while (!operation.isDone)
                yield return new WaitForSeconds(0);
        }
        foreach (string scene in scenesToLoad)
        {
            Debug.Log(scene);
            operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            while (!operation.isDone)
                yield return new WaitForSeconds(0);
        }
        _screen.Hide();
    }
}
