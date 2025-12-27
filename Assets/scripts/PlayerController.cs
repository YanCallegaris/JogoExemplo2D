using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public int maxHealth = 5;
	int currentHealth;
	public float speed;
	public InputAction moveAction;
	Rigidbody2D rigidbody2D;
	Vector2 move;
	void Start()
	{
		moveAction.Enable();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		currentHealth = maxHealth;
		move = moveAction.ReadValue<Vector2>();
		Debug.Log(move);
	}

    private void FixedUpdate()
    {
		Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
		transform.position = position;
	}

	void ChangeHealth(int amount)
	{
		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		Debug.Log(currentHealth + "/" + maxHealth);
	}
}
