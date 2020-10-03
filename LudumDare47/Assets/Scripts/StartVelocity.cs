using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVelocity : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private Vector2 _direction = Vector2.left;
    [SerializeField]
    private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.AddForce(_direction.normalized * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
