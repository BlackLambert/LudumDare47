using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreEnergy : MonoBehaviour
{
    [SerializeField]
    private float _energyPerSecods = 0.05f;
    private Game _game;

    // Start is called before the first frame update
    void Start()
    {
        _game = FindObjectOfType<Game>();
        if (_game == null)
            throw new NullReferenceException("There has to be a Game component in the scene");
    }

    // Update is called once per frame
    void Update()
    {
        _game.AddEnergy(_energyPerSecods * Time.deltaTime);
    }
}
