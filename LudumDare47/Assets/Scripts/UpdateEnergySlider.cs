using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateEnergySlider : MonoBehaviour
{
    [SerializeField]
    private Slider _slider = null;
    private Game _game;

    protected virtual void Start()
	{
        _game = FindObjectOfType<Game>();
        if (_game == null)
            throw new NullReferenceException("There has to be a game component in the scene");
    }


    protected virtual void Update()
	{
        _slider.value = _game.Energy;

    }
}
