using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEventArgs
{
    public Vector2 StartPoint { get; }
    public Vector2 Direction { get; }

    public DragEventArgs (Vector2 startPoint, Vector2 direction) 
    {
        StartPoint = startPoint;
        Direction = direction;
    }
}
