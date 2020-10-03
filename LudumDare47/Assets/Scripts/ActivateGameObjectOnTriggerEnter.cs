using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjectOnTriggerEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToHandle = null;
    [SerializeField]
    private bool _activate = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _objectToHandle.SetActive(_activate);
        Debug.Log("OnEnter");
    }
}
