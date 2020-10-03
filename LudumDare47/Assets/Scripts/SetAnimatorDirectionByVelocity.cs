using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorDirectionByVelocity : MonoBehaviour
{
    private const string _propertyName = "Direction";

    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private Rigidbody2D _referenceRigidbdy = null;

    protected virtual void Update()
	{
        float angle = Vector2.Angle(Vector2.right, _referenceRigidbdy.velocity);
        if (_referenceRigidbdy.velocity.y < 0)
            angle = 360 - angle;
        float direction = angle / 360;
        _animator.SetFloat(_propertyName, direction);
    }
}
