using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHelp : MonoBehaviour
{
    [SerializeField]
    private Button _toggleButton = null;
    [SerializeField]
    private GameObject _help = null;

    protected virtual void Start()
	{
        _toggleButton.onClick.AddListener(toggle);
    }

    protected virtual void OnDestroy()
	{
        _toggleButton.onClick.RemoveListener(toggle);
    }

    private void toggle()
	{
        StartCoroutine(lateToggle());
    }

    private IEnumerator lateToggle()
	{
        yield return new WaitForSeconds(0);
        yield return new WaitForSeconds(0);
        _help.SetActive(!_help.activeSelf);
    }

}
