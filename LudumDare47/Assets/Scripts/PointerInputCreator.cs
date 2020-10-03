using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInputCreator : MonoBehaviour
{
    [SerializeField]
    private MousePointerInput _mouseInputPrefab = null;
    [SerializeField]
    private TouchPointerInput _touchInputPrefab = null;

    protected virtual void Awake()
	{
        if (Application.isMobilePlatform && !Application.isEditor)
            Instantiate(_touchInputPrefab, this.transform);
        else
            Instantiate(_mouseInputPrefab, this.transform);
	}
}
