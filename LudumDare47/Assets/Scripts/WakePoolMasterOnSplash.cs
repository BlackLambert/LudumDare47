using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakePoolMasterOnSplash : MonoBehaviour, SplashReceiver
{
	private InfinityPoolLevel _level;
	[SerializeField]
	private float _wakeTime = 2f;
	[SerializeField]
	private AudioSource _awakeSound;
	[SerializeField]
	private AudioSource _shoutSound;
	[SerializeField]
	private AudioSource _snoreSound;



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
		_snoreSound.enabled = false;
		_awakeSound.enabled = true;
		yield return new WaitForSeconds(_wakeTime);
		_awakeSound.enabled = false;
		_shoutSound.enabled = true;
		_level.PoolMasterAwake = true;
	}
}
