using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggler : MonoBehaviour
{
    [SerializeField]
    private AudioSource _source;

    private SoundOptions _options;
    protected virtual void Start()
    {
        _options = FindObjectOfType<SoundOptions>();
        if (_options == null)
            throw new NullReferenceException("There has to be a SoundOptions Object in Scene");

        _source.mute = !_options.PlaySound;
        _options.OnPlaySoundChanged += toggleMute;
    }

    protected virtual void OnDestroy()
    {
        _options.OnPlaySoundChanged -= toggleMute;
    }

    private void toggleMute()
    {
        _source.mute = !_options.PlaySound;
    }
}
