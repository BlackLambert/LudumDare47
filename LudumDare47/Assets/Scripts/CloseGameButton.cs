using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseGameButton : MonoBehaviour
{
    [SerializeField]
    private Button _button = null;

    protected virtual void Start()
	{
		_button.onClick.AddListener(close);

    }

	protected virtual void OnDestroy()
	{
		_button.onClick.RemoveListener(close);
	}

	private void close()
	{
		Application.Quit();
	}
}
