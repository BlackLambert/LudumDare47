using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	[SerializeField]
	private List<string> _scenesToLoad = new List<string>();
	[SerializeField]
	private List<string> _scenesToUnload = new List<string>() {"Intro" };


	private LevelTransitioner _transitioner;

	protected virtual void Start()
	{
		_transitioner = FindObjectOfType<LevelTransitioner>();
		if (_transitioner == null)
			throw new NullReferenceException("There has to be a LevelTransitioner in the scene!");
	}

	public void Load()
	{
		_transitioner.Transition(_scenesToUnload, _scenesToLoad);
	}
}
