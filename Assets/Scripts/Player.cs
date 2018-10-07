using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private Collider2D netCollider, bottleCollider;
	public Animator animator;

	public AudioClip destroyTraumaClip;
	public AudioClip huntTraumaClip;
	public AudioClip destroyHopeClip;
	public AudioClip huntHopeClip;
	public AudioClip impactTraumaClip;
	public AudioSource effectsSource;

	private Score score;
	public Slider hopeSlider, traumaSlider;

	private void Awake()
	{
		score = GetComponent<Score>();
		animator = transform.Find("Char").GetComponent<Animator>();

		netCollider = transform.Find("Char/Weapons/Net").GetComponent<Collider2D>();
		bottleCollider = transform.Find("Char/Weapons/Bottle").GetComponent<Collider2D>();
	}

	private void Update()
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
				animator.SetTrigger("Net");
				break;
			case PickableType.Trauma:
				animator.SetTrigger("Bottle");
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
				effectsSource.PlayOneShot(impactTraumaClip);
				animator.SetTrigger("Damaged");
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
		effectsSource.PlayOneShot(huntTraumaClip);
		animator.SetTrigger("Damaged");
		score.Increase(-1);
	}

	private void DestroyHope()
	{
		
		animator.SetTrigger("Damaged");
		score.Increase(-1);
	}

	private void DestroyTrauma()
	{
		effectsSource.PlayOneShot(destroyTraumaClip);
		animator.SetTrigger("Healed");
		score.Increase(+1);
	}

	private void HuntHope()
	{
		effectsSource.PlayOneShot(huntHopeClip);
		animator.SetTrigger("Healed");
		score.Increase(+1);
	}
}
