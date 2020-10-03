using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CapSpeed : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float _cap = 5f;

    protected virtual void Update()
	{
        if (_rigidbody.velocity.magnitude <= _cap)
            return;
        _rigidbody.velocity = _rigidbody.velocity.normalized * _cap;
    }
}
