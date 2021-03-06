﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnBarrierLifted : MonoBehaviour
{
    [SerializeField]
    private GameObject _object = null;

	private BavariaOneLevel _level;

	protected void Start()
	{
		_level = FindObjectOfType<BavariaOneLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
		_level.OnBarrierProgressChanged += deactivateObject;
	}

	protected virtual void OnDestroy()
	{
		_level.OnBarrierProgressChanged -= deactivateObject;
	}

	private void deactivateObject()
	{
		if (_level.BarrierProgress < 1)
			return;
		_object.SetActive(false);
	}
}
