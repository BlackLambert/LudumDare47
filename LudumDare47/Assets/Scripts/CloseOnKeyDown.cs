using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOnKeyDown : MonoBehaviour
{
    [SerializeField]
    private KeyCode _key = KeyCode.Escape;

    protected virtual void Update()
	{
        if (Input.GetKeyDown(_key))
            Application.Quit();
	}
}
