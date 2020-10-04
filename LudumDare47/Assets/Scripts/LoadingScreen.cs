using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private string _displayBoolName = "Display";
    [SerializeField]
    private float _hideTime = 1;
    [SerializeField]
    private GameObject _canvas = null;

    protected virtual void Start()
	{

	}

    public void Display()
	{
        _animator.SetBool(_displayBoolName, true);
        _canvas.SetActive(true);
    }

    public void Hide()
	{
        StartCoroutine(doHide());
	}

    private IEnumerator doHide()
	{
        _animator.SetBool(_displayBoolName, false);
        yield return new WaitForSeconds(_hideTime);
        _canvas.SetActive(false);
    }
}
