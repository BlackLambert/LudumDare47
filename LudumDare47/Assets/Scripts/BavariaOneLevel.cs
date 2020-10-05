using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BavariaOneLevel : MonoBehaviour
{
    [SerializeField]
    private float _barrierProgressPerSplash = 0.34f;
    [SerializeField]
    private int _logsRequiredForBlock = 2;

    private float _barrierProgress = 0;
    private float _blockProgress = 0;

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
        get => _blockProgress >= 1;
    }

    public event Action OnBarrierProgressChanged;
    public event Action OnMainPathBlockedChanged;


    public void RaiseBarrier()
	{
        BarrierProgress = Mathf.Clamp01(BarrierProgress + _barrierProgressPerSplash);
    }

    public void BlockByLog()
	{
        _blockProgress += 1f / _logsRequiredForBlock;
        OnMainPathBlockedChanged?.Invoke();
    }
}
