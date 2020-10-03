using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetLayerOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToHandle = null;
    [SerializeField]
    private int _layer = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _objectToHandle.layer = _layer;
    }
}
