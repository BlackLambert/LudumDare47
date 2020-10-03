using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    public Rigidbody2D Rigidbody { get { return _rigidbody; } }
    [SerializeField]
    private GameObject _base = null;
    public GameObject Base { get { return _base; } }

    public void Dash(Vector2 direction)
	{
        _rigidbody.AddForce(direction);
	}

    public void Splash()
	{

	}
}
