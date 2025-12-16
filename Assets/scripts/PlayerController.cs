using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public InputAction leftAction;
	void Start()
	{

	}

	void Update()
	{
		float horizontal = 0f;
		float vertical = 0f;
		if (Keyboard.current.leftArrowKey.isPressed)
		{
			horizontal = -1f;
		}
		else if (Keyboard.current.rightArrowKey.isPressed)
		{
			horizontal = 1f;
		}

		if (Keyboard.current.downArrowKey.isPressed)
		{
			vertical = -1f;
		}
		else if (Keyboard.current.upArrowKey.isPressed)
		{
			vertical = 1f;
		}

		Debug.Log(horizontal);

		Vector2 position = transform.position;
		position.x = position.x + speed * horizontal;
		position.y = position.y + speed * vertical;
		transform.position = position;
	}
}
