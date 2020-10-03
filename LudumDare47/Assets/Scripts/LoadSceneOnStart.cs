using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnStart : MonoBehaviour
{
    [SerializeField]
    private string _sceneName;

    // Start is called before the first frame update
    protected virtual IEnumerator Start()
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(_sceneName);
    }
}
