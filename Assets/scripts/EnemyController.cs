using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	//Timer enemy
	public float changeTime = 3.0f;
	float timer;

	//Move enemy
	public bool isVertical;
	public float enemySpeed;
	int direction = 1;
	Rigidbody2D rigidbody2D;
	bool swapAxisOnNextTurn = false;

	//Animation Enemy
	Animator animator;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		timer = changeTime;
	}

	// Update is called once per frame
	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer < 0)
		{
			direction = -direction;
			timer = changeTime;

			if (swapAxisOnNextTurn)
			{
				isVertical = !isVertical;
			}

			swapAxisOnNextTurn = !swapAxisOnNextTurn;
		}
	}
	void FixedUpdate()
	{

		Vector2 position = rigidbody2D.position;
		if (isVertical)
		{
			position.y = position.y + enemySpeed * direction * Time.fixedDeltaTime;
			animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
		{
			position.x = position.x + enemySpeed * direction * Time.fixedDeltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
		rigidbody2D.MovePosition(position);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController player = other.gameObject.GetComponent<PlayerController>();
		if (player != null)
		{
			player.ChangeHealth(-1);
		}
	}
}
