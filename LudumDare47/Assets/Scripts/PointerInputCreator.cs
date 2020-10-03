using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInputCreator : MonoBehaviour
{
    [SerializeField]
    private MousePointerInput _mouseInputPrefab = null;
    [SerializeField]
    private TouchPointerInput _touchInputPrefab = null;

    protected virtual void Start()
	{
        if (Application.isMobilePlatform && !Application.isEditor)
            Instantiate(_touchInputPrefab);
        else
            Instantiate(_mouseInputPrefab);
	}
}
