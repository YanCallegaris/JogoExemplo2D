using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibleMyGame : MonoBehaviour
{
    public int healthIncrease = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if(controller != null && controller.health < controller.maxHealth)
        {
			controller.ChangeHealth(healthIncrease);
            Destroy(gameObject);
        }
    }
}
