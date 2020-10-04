using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField]
	private List<string> _scenesToLoad = new List<string>();

    public IEnumerator Load()
	{
		yield return new WaitForSeconds(0);
		foreach(string sceneName in _scenesToLoad)
		{
			if(sceneName == _scenesToLoad[0])
				SceneManager.LoadSceneAsync(sceneName);
			else
				SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		}
	}
}
