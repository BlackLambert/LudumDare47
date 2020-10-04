using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTriggerOnSplash : MonoBehaviour, SplashReceiver
{
    [SerializeField]
    private Animator _animator = null;
	[SerializeField]
	private string _triggerName = "Trigger";
	[SerializeField]
	private bool _onlyOnce = false;

	private bool _triggered = false;

	public void Trigger()
	{
		if (_triggered && _onlyOnce)
			return;
		_triggered = true;
		_animator.SetTrigger(_triggerName);
	}
}
