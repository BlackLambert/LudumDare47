using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerToPosition : MonoBehaviour
{
    [SerializeField]
    private Transform _hook = null;

    // Start is called before the first frame update
    void Start()
    {
        Player player = FindObjectOfType<Player>();
        player.Base.transform.position = _hook.position;
    }
}
