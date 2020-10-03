using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEventArgs
{
    public Vector2 Position { get; }
    
    public ClickEventArgs(Vector2 position)
	{
        Position = position;

    }
}
