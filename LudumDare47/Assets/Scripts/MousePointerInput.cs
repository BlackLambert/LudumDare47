﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointerInput : PointerInput
{
	public override event Action<ClickEventArgs> OnClick;
	public override event Action<DragEventArgs> OnDragFinished;
	public override event Action<DragEventArgs> OnDragging;

	protected Vector2 Distance { get { return (Vector2) Input.mousePosition - _downPos; } }

	private float _downTime = 0;
	private Vector2 _downPos = Vector2.zero;
	private bool _isDown = false;

	protected virtual void Update()
	{
		checkUp();
		checkDragging();
		increaseDownTime();
		checkDown();
	}

	private void checkDown()
	{
		if (_isDown || !Input.GetMouseButtonDown(0))
			return;
		_isDown = true;
		_downPos = Input.mousePosition;
	}

	private void checkUp()
	{
		if (!_isDown || !Input.GetMouseButtonUp(0))
			return;
		checkClick();
		checkDragFinished();
		clean();
	}

	private void checkClick()
	{
		if (_downTime > ClickMaxTime || Distance.magnitude > ClickPositionThreshold)
			return;
		OnClick(new ClickEventArgs(_downPos));
	}

	private void checkDragging()
	{
		if (!_isDown || Input.GetMouseButtonUp(0))
			return;
		if (Distance.magnitude < MinDragDistance)
			return;
		OnDragging(new DragEventArgs(_downPos, Distance));
	}

	private void checkDragFinished()
	{
		if (Distance.magnitude < MinDragDistance)
			return;
		OnDragFinished(new DragEventArgs(_downPos, Distance));
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
	}
}