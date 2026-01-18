using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneMyGame : MonoBehaviour
{
	public int healthDecrement = -1;
	private void OnTriggerStay2D(Collider2D other)
	{
		PlayerController controller = other.GetComponent<PlayerController>();
		if (controller != null)
		{
			controller.ChangeHealth(healthDecrement);
		}
	}
}
