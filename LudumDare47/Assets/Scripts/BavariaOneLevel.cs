using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BavariaOneLevel : MonoBehaviour
{
    [SerializeField]
    private float _barrierProgressPerSplash = 0.34f;

    private float _barrierProgress = 0;
    private bool _mainPathBlocked = false;

	public float BarrierProgress
    {
        get => _barrierProgress;
        protected set
        {
            if (_barrierProgress == value)
                return;
            _barrierProgress = value;
            OnBarrierProgressChanged?.Invoke();
        }
    }

    public bool MainPathBlocked
    {
        get => _mainPathBlocked;
        set
        {
            if (_mainPathBlocked == value)
                return;
            _mainPathBlocked = value;
            OnMainPathBlockedChanged?.Invoke();
        }
    }

    public event Action OnBarrierProgressChanged;
    public event Action OnMainPathBlockedChanged;


    public void RaiseBarrier()
	{
        BarrierProgress = Mathf.Clamp01(BarrierProgress + _barrierProgressPerSplash);
    }
}
