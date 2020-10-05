using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenesOnStart : MonoBehaviour
{
    [SerializeField]
    private List<string> _sceneNames;
    [SerializeField]
    private bool _additive = false;
    [SerializeField]
    private float _delay = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        FindObjectOfType<Coroutiner>().StartCoroutine(load());
    }

    private IEnumerator load()
	{
        yield return new WaitForSeconds(_delay);
        foreach (string scene in _sceneNames)
        {
            AsyncOperation operation;
            if (_additive || scene != _sceneNames[0])
                operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            else
                operation = SceneManager.LoadSceneAsync(scene);
            while (!operation.isDone)
                yield return new WaitForSeconds(0);
        }
    }
}
