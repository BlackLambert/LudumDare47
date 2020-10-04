using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomForceFrequently : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private float _force = 100;
    [SerializeField]
    private float _frequence = 0.5f;

    private Coroutine _coroutine = null;

    protected virtual void OnEnable()
	{
        _coroutine = StartCoroutine(applyForce());
	}

    protected virtual void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator applyForce()
	{
        Vector2 direction = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
        _rigidbody.AddForce(direction * _force);
        yield return new WaitForSeconds(_frequence);
        _coroutine = StartCoroutine(applyForce());
	}
}
