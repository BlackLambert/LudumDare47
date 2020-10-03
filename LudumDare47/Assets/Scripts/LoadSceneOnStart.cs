using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnStart : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private bool _additive = false;
    [SerializeField]
    private float _delay = 0;

    // Start is called before the first frame update
    protected virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(_delay);
        if (_additive)
            SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        else
            SceneManager.LoadSceneAsync(_sceneName);
    }
}
