using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PointerInput _pointerInput;
    private PlayerActionActivator _playerActionActivator;
    [SerializeField]
    private float _dashForce = 2;

    // Start is called before the first frame update
    void Start()
    {
        _pointerInput = FindObjectOfType<PointerInput>();
        if (_pointerInput == null)
            throw new NullReferenceException("There is no pointer input object in the scene");
        _playerActionActivator = FindObjectOfType<PlayerActionActivator>();
        if (_playerActionActivator == null)
            throw new NullReferenceException("There is no player action activator object in the scene");
        _pointerInput.OnClick += onClick;
        _pointerInput.OnDragFinished += onDrag;
    }

    private void onClick(ClickEventArgs args)
    {
        _playerActionActivator.RequestSplash();
    }

    private void onDrag(DragEventArgs args)
    {
        _playerActionActivator.RequestDash(args.Direction);
    }
}
