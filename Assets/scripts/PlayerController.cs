using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	void Start()
	{

	}

	void Update()
	{
		Vector2 position = transform.position;
		position.y = position.y + speed;
		position.x = position.x + speed;
		transform.position = position;
	}
}
