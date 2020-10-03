using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroImages : MonoBehaviour
{
    [SerializeField]
    private List<IntroImage> _images = new List<IntroImage>();
    private int _index = 0;

    public void ShowNext()
	{
        if (_index >= _images.Count)
            return;

        _images[_index].Hide();
        _index++;
    }

    public bool HasNext()
	{
        return _index + 1 < _images.Count;
    }
}
