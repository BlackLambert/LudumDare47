using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSettings : MonoBehaviour
{
    [SerializeField]
    private Button _toggleButton = null;
    [SerializeField]
    private GameObject _settings = null;

    protected virtual void Start()
	{
        _toggleButton.onClick.AddListener(toggle);
    }

    protected virtual void OnDestroy()
	{
        _toggleButton.onClick.RemoveListener(toggle);
    }

    private void toggle()
	{
        _settings.SetActive(!_settings.activeSelf);
    }
}
