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

    private Vector3 _formerPos = Vector3.zero;
    private float _percent = 1;

    public void Move()
	{
        _formerPos = _objectToMove.position;
        _percent = 0;
    }

    protected virtual void Update()
	{
        if (_percent >= 1)
            return;

        float time = Time.deltaTime;
        float delta = time / _duration;
        _percent = Mathf.Clamp01(delta + _percent);
        _objectToMove.position = _formerPos + _percent * (_target.position - _formerPos);

        if (_percent >= 0)
            OnFinish?.Invoke();
    }

    public event Action OnFinish;
}
