using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraCollider : MonoBehaviour
{
    [SerializeField]
    private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        CinemachineConfiner camConfier = FindObjectOfType<CinemachineConfiner>();
        camConfier.m_BoundingShape2D = _collider;
    }
}
