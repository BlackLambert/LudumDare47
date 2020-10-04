using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string _splashTriggerName = "Splash";

    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    [SerializeField]
    private GameObject _base = null;
    public GameObject Base { get { return _base; } }
    [SerializeField]
    private float _dashForce = 100f;
    [SerializeField]
    private Animator _animator = null;

    public void Dash(Vector2 direction)
	{
        _rigidbody.AddForce(direction.normalized * _dashForce);
	}

    public void Splash()
	{
        _animator.SetTrigger(_splashTriggerName);
    }
}
