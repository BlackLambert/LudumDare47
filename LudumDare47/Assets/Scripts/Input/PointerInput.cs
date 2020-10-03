using System;
using UnityEngine;

public abstract class PointerInput : MonoBehaviour
{
    public abstract event Action<ClickEventArgs> OnClick;
    public abstract event Action<DragEventArgs> OnDragFinished;
    public abstract event Action<DragEventArgs> OnDragging;

    [SerializeField]
    [Range(0, 7)]
    private float _clickPositionThreshold = 5;
    protected float ClickPositionThreshold { get { return _clickPositionThreshold; } }
    [SerializeField]
    private float _clickMaxTime = 0.3f;
    protected float ClickMaxTime { get { return _clickMaxTime; } }
    [SerializeField]
    [Range(8, 100)]
    private float _minDragDistance = 10;
    protected float MinDragDistance { get { return _minDragDistance; } }
}
