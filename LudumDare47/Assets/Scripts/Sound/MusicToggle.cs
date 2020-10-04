using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [SerializeField]
    private Toggle _toggle;

    private SoundOptions _options;

    protected virtual void Start()
	{
        _options = FindObjectOfType<SoundOptions>();
        if (_options == null)
            throw new NullReferenceException("There has to be a SoundOptions Object in Scene");

        updateView();
        _toggle.onValueChanged.AddListener(toggle);
        _options.OnPlayMusicChanged += updateView;
    }

    protected virtual void OnDestroy()
	{
        _options.OnPlayMusicChanged -= updateView;
        _toggle.onValueChanged.RemoveListener(toggle);
    }

    private void toggle(bool value)
	{
        _options.PlayMusic = value;
    }

    private void updateView()
	{
        if(_toggle.isOn != _options.PlayMusic)
            _toggle.isOn = _options.PlayMusic;
    }
}
