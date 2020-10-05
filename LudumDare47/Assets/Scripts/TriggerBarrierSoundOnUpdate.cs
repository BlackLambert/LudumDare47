using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerBarrierSoundOnUpdate : MonoBehaviour
{
    [SerializeField]
    private AudioSource _triggerSound;

    private BavariaOneLevel _level;

    protected void Start()
    {
        _level = FindObjectOfType<BavariaOneLevel>();
        if (_level == null)
            throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
        _level.OnBarrierProgressChanged += triggerSound;
    }

    protected virtual void OnDestroy()
    {
        _level.OnBarrierProgressChanged -= triggerSound;
    }

    private void triggerSound()
    {
        _triggerSound.Play();
    }
}
