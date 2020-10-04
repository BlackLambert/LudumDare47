using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePlayerInput : MonoBehaviour
{
    private PlayerActionActivator _activator;
	[SerializeField]
	private Button _button = null;
	[SerializeField]
	private bool _enable = true;
	[SerializeField]
	private bool _yield = false;

    protected virtual void Start()
	{
		_activator = FindObjectOfType<PlayerActionActivator>();
		if (_activator == null)
			throw new NullReferenceException("There has to be a PlayerActionActivator component in the scene");

		_button.onClick.AddListener(toggle);
	}

	protected virtual void OnDestroy()
	{
		_button.onClick.RemoveListener(toggle);
	}

	private void toggle()
	{
		if (_yield)
			StartCoroutine(lateToggle());
		else
			_activator.ActionsEnabled = _enable;
	}

	private IEnumerator lateToggle()
	{
		yield return new WaitForSeconds(0);
		_activator.ActionsEnabled = _enable;
		Debug.Log("Toggeling");
	}
}
