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

	private bool _hittable = false;
	private bool _hit = false;

	public bool Hittable {
		get => _hittable;
		set 
		{
			_hittable = value;
			_animator.SetBool(_inWhirlsBoolSetting, _hittable);
		} 
	}

	public void Trigger()
	{
		if (!Hittable && !_hit)
			return;
		_hit = true;
		_ram.Trigger();
		_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
		_moveToPosition.OnFinish += onMoved;
		_moveToPosition.Move();
		_lookAlongVelocity.enabled = false;
	}

	private void onMoved()
	{
		_moveToPosition.OnFinish -= onMoved;
		_base.rotation = Quaternion.Euler(0, 0, 90);
	}
}
