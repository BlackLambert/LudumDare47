﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private Vector3 _change = new Vector3(0, 0, 1);

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.transform.position += _change;
    }
}
