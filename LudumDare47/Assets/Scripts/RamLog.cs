using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamLog : MonoBehaviour
{
	[SerializeField]
	private string _triggerName = "Ram";
	[SerializeField]
	private Animator _animator = null;

	public void Trigger()
	{
		_animator.SetTrigger(_triggerName);
	}

	
}
