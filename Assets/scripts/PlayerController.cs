using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	//Variables Invecibility
	public float timeInvencible = 2.0f;
	bool isInvencible;
	float damageCooldown;

	// Variables Health
	public int maxHealth = 5;
	public int health { get { return currentHealth; }}
	int currentHealth;

	//Variables Move
	public float speed;
	public InputAction moveAction;
	Rigidbody2D rigidbody2D;
	Vector2 move;

	//Animator
	Animator animator;
	Vector2 moveDirection = new Vector2(1,0);

	void Start()
	{
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
		moveAction.Enable();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		move = moveAction.ReadValue<Vector2>();
		if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
		{
			moveDirection.Set(move.x, move.y);
			moveDirection.Normalize();
		}

		animator.SetFloat("Look X", moveDirection.x);
		animator.SetFloat("Look Y", moveDirection.y);
		animator.SetFloat("Speed", move.magnitude);

		if (isInvencible)
		{
			damageCooldown -= Time.deltaTime;
			if(damageCooldown < 0)
			{
				isInvencible = false;
			}
		}
	}

    private void FixedUpdate()
    {
		Vector2 position = (Vector2)rigidbody2D.position + move * speed * Time.deltaTime;
		rigidbody2D.MovePosition(position);
	}

	public void ChangeHealth(int amount)
	{
		if (amount < 0)
		{
			if (isInvencible)
			{
				return;
			}
			isInvencible = true;
			damageCooldown = timeInvencible;
		}
		animator.SetTrigger("Hit");
		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		UIHandlerMyGame.instance.SetHealthValue(currentHealth / (float)maxHealth);
	}
}
