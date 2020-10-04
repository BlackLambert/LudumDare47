using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidChainBreaker : MonoBehaviour
{
	private InfinityPoolLevel _level;

	[SerializeField]
	private List<LevelOneChild> _children = new List<LevelOneChild>();
	[SerializeField]
	private GameObject _chainObject = null;


	protected virtual void Start()
	{
		_level = FindObjectOfType<InfinityPoolLevel>();
		if (_level == null)
			throw new NullReferenceException("There has to be a InfinityPoolLevel component in the scene");
		_level.OnPoolMasterAwakeChanged += breakChain;
	}

	protected virtual void OnDestroy()
	{
		_level.OnPoolMasterAwakeChanged -= breakChain;
	}

	private void breakChain()
	{
		Joint2D joint = _chainObject.GetComponentInChildren<Joint2D>();
		joint.breakForce = 0;
		foreach (LevelOneChild child in _children)
			child.DisableChain();
		Destroy(_chainObject);
	}

}
