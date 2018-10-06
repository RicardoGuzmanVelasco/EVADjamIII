using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Collider2D netCollider, bottleCollider;
	private Animator netAnimator;

	private void Awake()
	{
		netAnimator = transform.Find("Weapons").GetComponent<Animator>();

		netCollider = transform.Find("Weapons/Net").GetComponent<Collider2D>();
		bottleCollider = transform.Find("Weapons/Bottle").GetComponent<Collider2D>();
	}

	private void FixedUpdate()
	{
		if(Input.GetButtonDown("Net"))
			Attack(PickableType.Hope);
		if(Input.GetButtonDown("Bottle"))
			Attack(PickableType.Trauma);
	}

	private void Attack(PickableType pickableType)
	{
		switch(pickableType)
		{
			case PickableType.Hope:
				netAnimator.SetTrigger("Net");
				break;
			case PickableType.Trauma:
				netAnimator.SetTrigger("Bottle");
				break;
			default:
				break;
		}
	}

	public void Impact(PickableType pickableType)
	{
		switch(pickableType)
		{
			case PickableType.Hope:
				//Hope oversteps you.
				break;
			case PickableType.Trauma:
				Debug.Log("Traume hurts you!");
				break;
			default:
				Debug.LogError("Unknown type.");
				break;
		}
	}

	internal void Impact(PickableType pickableType, PickableType weaponType)
	{
		if(pickableType == PickableType.Hope && weaponType == PickableType.Hope)
			Debug.Log("Hope haunted by net!");
		if(pickableType == PickableType.Trauma && weaponType == PickableType.Trauma)
			Debug.Log("Trauma destroyed by bottle!");
	}
}
