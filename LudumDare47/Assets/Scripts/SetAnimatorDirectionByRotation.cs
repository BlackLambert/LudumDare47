using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimatorDirectionByRotation : MonoBehaviour
{
    private const string _propertyName = "Direction";

    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private Transform _referenceTransform = null;

    protected virtual void Update()
	{
        float direction = _referenceTransform.rotation.eulerAngles.z / (360);
        //Debug.Log($"Angle: {_referenceTransform.rotation.eulerAngles.z} | Value: {direction}");
        _animator.SetFloat(_propertyName, direction);
    }
}
