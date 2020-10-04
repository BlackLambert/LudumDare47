using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField]
    private string _currentLevel = "Level";
    [SerializeField]
    private string _nextLevel = "Level";

	private LevelTransitioner _transitioner;


	protected virtual void Start()
	{
		_transitioner = FindObjectOfType<LevelTransitioner>();
		if (_transitioner == null)
			throw new NullReferenceException("There has to be a LevelTransitioner in the scene!");
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		if (player == null)
			return;
		_transitioner.Transition(_currentLevel, _nextLevel);
	}
}
