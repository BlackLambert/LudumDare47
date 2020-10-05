using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatOnBarrierProgess : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private string _floatName = "FillState";

    private BavariaOneLevel _level;

	protected void Start()
	{
		_level = FindObjectOfType<BavariaOneLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
		_level.OnBarrierProgressChanged += updateFloat;
	}

	protected virtual void OnDestroy()
	{
		_level.OnBarrierProgressChanged -= updateFloat;
	}

	private void updateFloat()
	{
		_animator.SetFloat(_floatName, _level.BarrierProgress);
	}
}
