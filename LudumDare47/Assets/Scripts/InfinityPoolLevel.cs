using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPoolLevel : MonoBehaviour
{
    private bool _poolMasterAwake = false;
    public event Action OnPoolMasterAwakeChanged;
    public bool PoolMasterAwake 
    { 
        get { return _poolMasterAwake; } 
        set
		{
            if (_poolMasterAwake == value)
                return;
            _poolMasterAwake = value;
            OnPoolMasterAwakeChanged?.Invoke();
        }
    }
}
