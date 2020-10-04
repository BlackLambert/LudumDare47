using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMissingEnergy : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private string _triggerName;

    private PlayerActionActivator _activator;
    
    protected virtual void Start()
	{
        _activator = FindObjectOfType<PlayerActionActivator>();
        if (_activator == null)
            throw new NullReferenceException("There has to be a PlayerActionActivator component in the scene.");
        _activator.OnNotEnoughEnergy += trigger;
    }

    protected virtual void OnDestroy()
	{
        _activator.OnNotEnoughEnergy -= trigger;
    }

    private void trigger()
	{
        _animator.SetTrigger(_triggerName);

    }
}
