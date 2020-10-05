using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLogHitable : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Log log = collision.transform.GetComponent<Log>();
		if (log == null)
			return;
		log.Hittable = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		Log log = collision.transform.GetComponent<Log>();
		if (log == null)
			return;
		log.Hittable = false;
	}
}
