using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAlongVelocity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private Transform _objectToHandle = null;

    protected virtual void Update()
	{
        if (_rigidbody.velocity.magnitude == 0)
            return;
        float angle = Vector2.Angle(Vector2.up, _rigidbody.velocity);
        if (_rigidbody.velocity.y < 0)
            angle = 360 - angle;
        _objectToHandle.rotation = Quaternion.Euler(0, 0, angle);
    }
}
