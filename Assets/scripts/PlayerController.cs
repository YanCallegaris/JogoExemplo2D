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

	//Projectile
	public GameObject projectilePrefab;
	public float launchForce = 300;

	//talk
	public InputAction talkAction;

	void Start()
	{
		moveAction.Enable();
		talkAction.Enable();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		move = moveAction.ReadValue<Vector2>();
		if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
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
			if (damageCooldown < 0)
			{
				isInvencible = false;
			}
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			Launch();
		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			FindFriend();
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
			animator.SetTrigger("Hit");
		}
		currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
		UIHandlerMyGame.instance.SetHealthValue(currentHealth / (float)maxHealth);
	}

	void Launch()
	{
		GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2D.position + Vector2.up * .5f, Quaternion.identity);
		ProjectileMyGame projectile = projectileObject.GetComponent<ProjectileMyGame>();
		projectile.Launch(moveDirection, launchForce);
		animator.SetTrigger("Launch");
	}

	void FindFriend()
	{
		Debug.Log("entrou1");
		RaycastHit2D hit = Physics2D.Raycast(rigidbody2D.position + Vector2.up * 0.2f, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
		if(hit.collider != null)
		{
            Debug.Log("entrou1");

            NonPlayerCharacterMyGame character = hit.collider.GetComponent<NonPlayerCharacterMyGame>();
			Debug.Log(character == null);
			if (character != null)
			{
                Debug.Log("entrou1");

                UIHandlerMyGame.instance.DisplayDialogue();
			}
		}
	}
}
