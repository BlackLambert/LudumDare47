using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneChild : MonoBehaviour
{
    [SerializeField]
    private string _disableChainTrigger = "Trigger";
    [SerializeField]
    private Animator _animator = null;
    [SerializeField]
    private Rigidbody2D _rigidbody = null;
    [SerializeField]
    private Joint2D _joint = null;

    public void DisableChain()
	{
        _animator.SetTrigger(_disableChainTrigger);
        _joint.breakForce = 0;
    }
}
