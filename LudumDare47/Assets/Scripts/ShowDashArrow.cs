using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDashArrow : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _group = null;
    [SerializeField]
    private RectTransform _arrow = null;

    private PointerInput _pointer;

    protected virtual void Start()
	{
        _pointer = FindObjectOfType<PointerInput>();
        if (_pointer == null)
            throw new NullReferenceException("There has to be a PointerInput in the scene!");

        _group.alpha = 0;
        _pointer.OnDragStart += onDragStart;
        _pointer.OnDragFinished += onDragFinished;
        _pointer.OnDragging += onDragging;
    }

    protected virtual void OnDestroy()
	{
        _pointer.OnDragStart -= onDragStart;
        _pointer.OnDragFinished -= onDragFinished;
        _pointer.OnDragging -= onDragging;
    }

	private void onDragStart(DragEventArgs obj)
	{
        _group.alpha = 1;

    }

    private void onDragFinished(DragEventArgs obj)
    {
        _group.alpha = 0;
    }

    private void onDragging(DragEventArgs args)
	{
        float angle = Mathf.Atan2(args.Direction.y, args.Direction.x) * Mathf.Rad2Deg;
        _arrow.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
