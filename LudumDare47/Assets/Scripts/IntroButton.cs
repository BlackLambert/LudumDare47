using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroButton : MonoBehaviour
{
    [SerializeField]
    private Button _button = null;
	[SerializeField]
	private LevelLoader _loader = null;
	[SerializeField]
	private IntroImages _images = null;

    protected virtual void Start()
	{
		_button.onClick.AddListener(onClick);
	}

    protected virtual void OnDestroy()
	{
		_button.onClick.RemoveListener(onClick);
	}

	private void onClick()
	{
		if (_images.HasNext())
			_images.ShowNext();
		else
		{
			_button.interactable = false;
			_loader.Load();
		}
	}
}
