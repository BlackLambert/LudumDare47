using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerActionActivator : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float _energyPerDash = 0.3f;
    [SerializeField]
    [Range(0, 1)]
    private float _energyPerSplash = 0.2f;
    [SerializeField]
    private float _dashDuration = 1f;
    [SerializeField]
    private float _splashDuration = 0.66f;
    [SerializeField]
    private AudioSource _dashSound;


    public event Action OnNotEnoughEnergy;

    private float _dashTimeStamp = 0;
    private float _splashTimeStamp = 0;
    private Game _game;
    private Player _player;
    public bool ActionsEnabled { get; set; } = true;

    protected virtual void Start()
	{
        _game = FindObjectOfType<Game>();
        if (_game == null)
            throw new NullReferenceException("There has to be a Game component in the Scene");
        _player = FindObjectOfType<Player>();
        if (_player == null)
            throw new NullReferenceException("There has to be a Player component in the Scene");
    }

    public void RequestDash(Vector2 direction)
	{
        float timeDifference = Time.realtimeSinceStartup - _dashTimeStamp;
        if (timeDifference < _dashDuration || !ActionsEnabled)
            return;
        if (!_game.HasEnergy(_energyPerDash))
        {
            OnNotEnoughEnergy?.Invoke();
            return;
        }
        _game.RequestEnergy(_energyPerDash);
        _dashTimeStamp = Time.realtimeSinceStartup;
        _player.Dash(direction, _dashDuration);
        _dashSound.Play();
    }

    public void RequestSplash()
	{
        float timeDifference = Time.realtimeSinceStartup - _splashTimeStamp;
        if (timeDifference < _splashDuration || !ActionsEnabled)
            return;
        if (!_game.HasEnergy(_energyPerSplash))
        {
            OnNotEnoughEnergy?.Invoke();
            return;
        }
        _game.RequestEnergy(_energyPerSplash);
        _splashTimeStamp = Time.realtimeSinceStartup;
        _player.Splash();
    }
}
