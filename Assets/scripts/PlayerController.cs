using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public InputAction moveAction;
	void Start()
	{
		moveAction.Enable();
	}

	void Update()
	{
		Vector2 move = moveAction.ReadValue<Vector2>();
		Debug.Log(move);
		Vector2 position = (Vector2)transform.position + move * speed;   
		transform.position = position;
	}
}
