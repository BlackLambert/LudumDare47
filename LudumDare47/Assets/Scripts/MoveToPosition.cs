using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _target = null;
    [SerializeField]
    private Transform _objectToMove = null;
    [SerializeField]
    private float _duration = 3;

    private Vector3 _distance = Vector3.zero;
    private float _secondsMoving = 0;

    public void Move()
	{
        _distance = _target.position - _objectToMove.position;
        _secondsMoving = _duration;
    }

    protected virtual void Update()
	{
        if (_secondsMoving <= 0)
            return;

        float time = Mathf.Min(Time.deltaTime, _secondsMoving);
        float delta = _duration / time;
        _secondsMoving -= Time.deltaTime;
        Vector3 deltaDistance = _distance * delta;
        _objectToMove.position += deltaDistance;

        if (_secondsMoving <= 0)
            OnFinish?.Invoke();
    }

    public event Action OnFinish;
}
