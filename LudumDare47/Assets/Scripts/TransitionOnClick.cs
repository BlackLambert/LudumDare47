using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionOnClick : MonoBehaviour
{
	[SerializeField]
	private string _currentLevel = "Level";
	[SerializeField]
	private string _nextLevel = "Level";
	[SerializeField]
	private Button _button = null;

	private LevelTransitioner _transitioner;


	protected virtual void Start()
	{
		_transitioner = FindObjectOfType<LevelTransitioner>();
		if (_transitioner == null)
			throw new NullReferenceException("There has to be a LevelTransitioner in the scene!");
		_button.onClick.AddListener(transition);
	}

	protected virtual void OnDestroy()
	{
		_button.onClick.RemoveListener(transition);
	}


	private void transition()
	{
		_transitioner.Transition(_currentLevel, _nextLevel);
	}
}
