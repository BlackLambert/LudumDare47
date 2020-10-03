using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTester : MonoBehaviour
{
    private PointerInput _pointerInput;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _pointerInput = FindObjectOfType<PointerInput>();
        if (_pointerInput == null)
            throw new NullReferenceException("There is no pointer input object in the scene");
        _pointerInput.OnClick += onClick;
        _pointerInput.OnDragFinished += onDrag;
        _pointerInput.OnDragging += onDragging;
    }

    protected virtual void OnDestroy()
	{
        _pointerInput.OnClick -= onClick;
        _pointerInput.OnDragFinished -= onDrag;
    }
   
    private void onClick(ClickEventArgs args)
	{
        Debug.Log($"Player clicked at position {args.Position}");
	}

    private void onDrag(DragEventArgs args)
	{
        Debug.Log($"Player draged at position {args.StartPoint} in direction of {args.Direction}");
	}

    private void onDragging(DragEventArgs args)
	{
        Debug.Log($"Player is dragging at position {args.StartPoint} in direction of {args.Direction}");
    }
}
