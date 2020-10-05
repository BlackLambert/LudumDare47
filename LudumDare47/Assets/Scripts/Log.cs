using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour, DashReceiver
{
    [SerializeField]
    private RamLog _ram = null;
	[SerializeField]
	private MoveToPosition _moveToPosition = null;
	[SerializeField]
	private Rigidbody2D _rigidbody2D = null;
	[SerializeField]
	private Transform _base;
	[SerializeField]
	private LookAlongVelocity _lookAlongVelocity = null;
	[SerializeField]
	private Animator _animator = null;
	[SerializeField]
	private string _inWhirlsBoolSetting = "InWhirles";
	[SerializeField]
	private SetAnimatorDirectionByVelocity _velocitySetter = null;

	private bool _hittable = false;
	private bool _hit = false;
	private BavariaOneLevel _level;

	public bool Hittable {
		get => _hittable;
		set 
		{
			_hittable = value;
			_animator.SetBool(_inWhirlsBoolSetting, _hittable);
		} 
	}

	protected virtual void Start()
	{
		_level = FindObjectOfType<BavariaOneLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
	}

	public void Trigger()
	{
		if (!Hittable && !_hit)
			return;
		_hit = true;
		_ram.Trigger();
		Destroy(_rigidbody2D);
		Destroy(_velocitySetter);
		_moveToPosition.OnFinish += onMoved;
		_moveToPosition.Move();
		_lookAlongVelocity.enabled = false;
	}

	private void onMoved()
	{
		_moveToPosition.OnFinish -= onMoved;
		_base.rotation = Quaternion.Euler(0, 0, 90);
		_level.BlockByLog();
	}
}
