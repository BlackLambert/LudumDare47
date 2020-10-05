using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DashCollisionTriggerer : MonoBehaviour
{
	[SerializeField]
	private Player _player;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (!_player.Dashing)
			return;

		IEnumerable<DashReceiver> receivers = collision.collider.GetComponentsInChildren<DashReceiver>();
		foreach (DashReceiver receiver in receivers)
			receiver.Trigger();
	}
}
