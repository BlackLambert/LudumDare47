using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private float _energy = 1;
    public float Energy { get { return _energy; } }

    public void AddEnergy(float amount)
	{
        if (amount < 0)
            throw new ArgumentException("The amount has to be larger than 0.");
        _energy = Mathf.Clamp01(_energy + amount);
    }

    public void RequestEnergy(float amount)
    {
        if (amount > _energy)
            throw new ArgumentException("The amount has to be smaller than the energy.");
        _energy = Mathf.Clamp01(_energy - amount);
    }

    public bool HasEnergy(float amount)
	{
        return amount <= _energy;
	}
}
