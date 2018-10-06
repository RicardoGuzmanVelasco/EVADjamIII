using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private Collider2D netCollider, bottleCollider;
	private Animator netAnimator;

	public Score score;
	public Slider hopeSlider, traumaSlider;

	private void Awake()
	{
		score = new Score(hopeSlider, traumaSlider);
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
				//No change in score. Hope oversteps you.
				break;
			case PickableType.Trauma:
				score.Increase(-1);
				break;
			default:
				Debug.LogError("Unknown type.");
				break;
		}
	}

	internal void Impact(PickableType pickableType, PickableType weaponType)
	{
		if(pickableType == PickableType.Hope && weaponType == PickableType.Hope)
			HuntHope();
		if(pickableType == PickableType.Trauma && weaponType == PickableType.Trauma)
			DestroyTrauma();
		if(pickableType == PickableType.Hope && weaponType == PickableType.Trauma)
			DestroyHope();
		if(pickableType == PickableType.Trauma && weaponType == PickableType.Hope)
			HuntTrauma();
	}

	private void HuntTrauma()
	{
		score.Increase(-1);
	}

	private void DestroyHope()
	{
		score.Increase(-1);
	}

	private void DestroyTrauma()
	{
		score.Increase(+1);
	}

	private void HuntHope()
	{
		score.Increase(+1);
	}
}
