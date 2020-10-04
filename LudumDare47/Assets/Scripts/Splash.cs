using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField]
    private Animator _front;
    [SerializeField]
    private Animator _back;
    [SerializeField]
    private string _triggerName = "Splash";
    [SerializeField]
    private GameObject _base;
    [SerializeField]
    private float _destroyAfterSeconds = 1f;

    protected virtual void Start()
	{
        StartCoroutine(trigger());
    }

    private IEnumerator trigger()
	{
        _front.SetTrigger(_triggerName);
        _back.SetTrigger(_triggerName);
        yield return new WaitForSeconds(_destroyAfterSeconds);
        Destroy(_base);
    }
}
