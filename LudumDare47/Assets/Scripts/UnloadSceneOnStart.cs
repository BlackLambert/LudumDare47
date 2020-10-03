using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadSceneOnStart : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;
    [SerializeField]
    private float _delay = 2;

    // Start is called before the first frame update
    protected virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(0);
        SceneManager.UnloadSceneAsync(_sceneName);
    }
}
