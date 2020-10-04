using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakePoolMasterOnSplash : MonoBehaviour, SplashReceiver
{
	private InfinityPoolLevel _level;
	[SerializeField]
	private float _wakeTime = 2f;


	protected virtual void Start()
	{
		_level = FindObjectOfType<InfinityPoolLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a InfinityPoolLevel component in the scene");
	}

	public void Trigger()
	{
		StartCoroutine(delayedTrigger());
	}

	private IEnumerator delayedTrigger()
	{
		yield return new WaitForSeconds(_wakeTime);
		_level.PoolMasterAwake = true;
	}
}
