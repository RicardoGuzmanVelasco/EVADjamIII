using System;
using UnityEngine;

public class Pickable : MonoBehaviour
{
	public float speed = 3;
	public PickableType type;
	public bool antigenerated = false;

	private void Start()
	{
		if(antigenerated)
			speed *= -1;
	}

	private void Update()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * speed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
			collision.GetComponent<Player>().Impact(type);

			GetComponent<Collider2D>().enabled = false;
		}

		if(collision.tag == "Weapon")
		{
			Weapon weapon = collision.GetComponent<Weapon>();
			weapon.Hunt(type);
			if(weapon.type == PickableType.Trauma && type == PickableType.Trauma)
			{
				Vanish();
			}
		}
	}

	private void Vanish()
	{
		Destroy(gameObject);
	}
}
