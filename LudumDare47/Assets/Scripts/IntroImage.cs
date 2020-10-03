using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroImage : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup _group = null;
	[SerializeField]
	private float _hideSeconds = 0.33f;

	private float _alpha = 1f;
	private bool _hide = false;

    public void Hide()
	{
		_hide = true;
	}

	protected virtual void Update()
	{ 
		if (_hide == false || _alpha == 0)
			return;
		float delta = Time.deltaTime / _hideSeconds;
		_group.alpha = _group.alpha - delta;
	}
}
