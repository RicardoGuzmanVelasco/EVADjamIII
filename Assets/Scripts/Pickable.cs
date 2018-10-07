using System;
using UnityEngine;

public class Pickable : MonoBehaviour
{
	public float speed = 3;
	public PickableType type;
	public bool antigenerated = false;
	private bool ranAway = false;

	private void Start()
	{
		if(antigenerated)
			speed *= -1;

		//Hopes goes to you until they collides with HopesActivator.
		if(type == PickableType.Hope)
			speed *= -1;
	}

	private void Update()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * speed);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(!ranAway && type == PickableType.Hope && collision.tag == "Respawn")
		{
			ranAway = true;
			speed *= -3;
			return;
		}

		if(collision.tag == "Player")
		{
			collision.GetComponent<Player>().Impact(type);

			GetComponent<Collider2D>().enabled = false;

			if(type == PickableType.Trauma)
				Vanish();
		}

		if(collision.tag == "Weapon")
		{
			Weapon weapon = collision.GetComponent<Weapon>();
			weapon.Hunt(type);
			Vanish();
		}
	}

	private void Vanish()
	{
		Destroy(gameObject);
	}
}
