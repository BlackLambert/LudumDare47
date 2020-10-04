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
    [SerializeField]
    private GameObject _splashRadiusObject = null;
    [SerializeField]
    private Animator _splashBackAnimator = null;
    [SerializeField]
    private Animator _splashFrontAnimator = null;

    protected virtual void Start()
	{
        _splashRadiusObject.SetActive(false);
    }

    public void Dash(Vector2 direction)
	{
        _rigidbody.AddForce(direction.normalized * _dashForce);
	}

    public void Splash()
	{
        StartCoroutine(triggerSplash());
    }

    private IEnumerator triggerSplash()
	{
        _animator.SetTrigger(_splashTriggerName);
        yield return new WaitForSeconds(0.2f);
        _splashBackAnimator.SetTrigger(_splashTriggerName);
        _splashFrontAnimator.SetTrigger(_splashTriggerName);
        _splashRadiusObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _splashRadiusObject.SetActive(false);
    }
}
