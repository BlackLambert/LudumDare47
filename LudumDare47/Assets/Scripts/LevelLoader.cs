using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField]
	private List<string> _scenesToLoad = new List<string>();
	[SerializeField]
	private List<string> _scenesToUnload = new List<string>();

    public IEnumerator Load()
	{
		foreach(string sceneName in _scenesToLoad)
		{
			yield return new WaitForSeconds(0);
			SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		}
		foreach (string sceneName in _scenesToUnload)
		{
			yield return new WaitForSeconds(0);
			SceneManager.UnloadSceneAsync(sceneName);
		}
	}
}
