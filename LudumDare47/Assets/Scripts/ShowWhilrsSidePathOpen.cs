using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWhilrsSidePathOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject _whirls = null;

    private BavariaOneLevel _level;

    protected virtual void Start()
	{
        _whirls.SetActive(false);
        _level = FindObjectOfType<BavariaOneLevel>();
        if (_level == null)
            throw new NullReferenceException("There has to be a BavariaOneLevel component in the scene!");
        _level.OnBarrierProgressChanged += activateWhirles;
    }

    protected virtual void OnDestroy()
    {
        _level.OnBarrierProgressChanged -= activateWhirles;
    }

    private void activateWhirles()
	{
        if (_level.BarrierProgress != 1)
            return;
        _whirls.SetActive(true);
    }
}
