using System.Collections.Generic;
using UnityEngine;

public class TriggerSplashReceivers : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        IEnumerable<SplashReceiver> receivers = col.gameObject.GetComponentsInChildren<SplashReceiver>();
        foreach (SplashReceiver receiver in receivers)
            receiver.Trigger();
    }
}
