using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation2D : MonoBehaviour
{
    [SerializeField]
    private float _fixedAngle = 0;
    [SerializeField]
    private Transform _transform = null;



    protected virtual void FixedUpdate()
	{
        _transform.rotation = Quaternion.Euler(new Vector3(_transform.rotation.x, _transform.rotation.y, _fixedAngle));
    }
}
