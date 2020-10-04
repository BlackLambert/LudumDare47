using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOptions : MonoBehaviour
{
    private bool _playSound = true;
    private bool _playMusic = true;
	public event Action OnPlaySoundChanged;
	public event Action OnPlayMusicChanged;

	public bool PlaySound
	{
		get { return _playSound; }
		set 
		{
			if (_playSound == value)
				return;
			_playSound = value;
			OnPlaySoundChanged?.Invoke();
		}
	}
	public bool PlayMusic
	{
		get { return _playMusic; }
		set
		{
			if (_playMusic == value)
				return;
			_playMusic = value;
			OnPlayMusicChanged?.Invoke();
		}
	}
}
