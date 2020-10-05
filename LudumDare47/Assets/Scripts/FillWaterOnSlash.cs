using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillWaterOnSlash : MonoBehaviour, SplashReceiver
{
	private BavariaOneLevel _level;

	protected virtual void Start()
	{
		_level = FindObjectOfType<BavariaOneLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
	}

	public void Trigger()
	{
		_level.RaiseBarrier();
		Debug.Log(_level.BarrierProgress);
	}
}
