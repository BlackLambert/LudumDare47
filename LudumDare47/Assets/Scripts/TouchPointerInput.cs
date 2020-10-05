using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchPointerInput :  PointerInput
{
	public override event Action<ClickEventArgs> OnClick;
	public override event Action<DragEventArgs> OnDragFinished;
	public override event Action<DragEventArgs> OnDragging;
	public override event Action<DragEventArgs> OnDragStart;

	protected Vector2 Distance { get { return TouchOfID.position - _downPos; } }
	protected Touch TouchOfID { get { return Input.touches.FirstOrDefault(t => t.fingerId == _finerID); } }

	private float _downTime = 0;
	private Vector2 _downPos = Vector2.zero;
	private int _finerID = 0;
	private bool _isDown = false;
	private bool _dragging = false;

	protected virtual void Update()
	{
		checkUp();
		checkDragging();
		increaseDownTime();
		checkDown();
	}

	private void checkDown()
	{
		if (_isDown || Input.touchCount <= 0 || Input.touches[0].phase != TouchPhase.Began)
			return;
		_isDown = true;
		_downPos = Input.touches[0].position;
		_finerID = Input.touches[0].fingerId;
	}

	private void checkUp()
	{
		if (!_isDown || TouchOfID.phase != TouchPhase.Ended && TouchOfID.phase != TouchPhase.Canceled)
			return;
		checkClick();
		checkDragFinished();
		clean();
	}

	private void checkClick()
	{
		if (_downTime > ClickMaxTime || Distance.magnitude > ClickPositionThreshold)
			return;
		OnClick?.Invoke(new ClickEventArgs(_downPos));
	}

	private void checkDragging()
	{
		if (!_isDown || TouchOfID.phase == TouchPhase.Ended || TouchOfID.phase == TouchPhase.Canceled)
			return;
		if (Distance.magnitude < MinDragDistance)
			return;
		if (!_dragging)
		{
			_dragging = true;
			OnDragStart?.Invoke(new DragEventArgs(_downPos, Distance));
		}
		OnDragging?.Invoke(new DragEventArgs(_downPos, Distance));
	}

	private void checkDragFinished()
	{
		if (Distance.magnitude < MinDragDistance)
			return;
		OnDragFinished?.Invoke(new DragEventArgs(_downPos, Distance));
	}

	private void increaseDownTime()
	{
		if (!_isDown)
			return;
		_downTime += Time.deltaTime;
	}

	private void clean()
	{
		_downPos = Vector2.zero;
		_isDown = false;
		_downTime = 0;
		_dragging = false;
	}
}
