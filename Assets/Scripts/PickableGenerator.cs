using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGenerator : MonoBehaviour
{
	public Transform floor;

	private float time;
	private bool mainOn = false, antiOn = false;

	public List<GameObject> msgs;

	public PickableType mainPickable;
	public GameObject hopePrefab, traumaPrefab;

	private float coolDown = 5;
	public bool showMsgs;

	private void Start()
	{
		time = 0f;
		if(mainPickable == PickableType.Hope)
			mainOn = true;
		StartCoroutine(SpawnPickable());
	}

	private void Update()
	{
		time += Time.deltaTime;

		#region TimeScheduler
		if(time > 25)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = true;
					antiOn = true;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = true;
					break;
				default:
					break;
			}
		else if(time > 24)
			HideNarrative();
		else if(time > 22)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = true;
					antiOn = false;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = true;
					break;
				default:
					break;
			}
		else if(time > 21)
			ShowNarrative(7);
		else if(time > 20)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = true;
					antiOn = false;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = false;
					break;
				default:
					break;
			}
		else if(time > 18)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = true;
					antiOn = true;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = false;
					break;
				default:
					break;
			}
		else if(time > 15)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = true;
					antiOn = false;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = false;
					break;
				default:
					break;
			}
		else if(time > 13)
			HideNarrative();
		else if(time > 10)
			switch(mainPickable)
			{
				case PickableType.Hope:
					mainOn = false;
					antiOn = false;
					break;
				case PickableType.Trauma:
					mainOn = true;
					antiOn = false;
					break;
				default:
					break;
			}
		else if(time > 9.0)
			ShowNarrative(5);
		else if(time > 6)
			HideNarrative();
		else if(time > 3)
			ShowNarrative(0);
		#endregion
	}

	private void ShowNarrative(int v)
	{
		if(!showMsgs) return;
		for(int i = 0; i < msgs.Count; i++)
			msgs[i].SetActive(i==v);
	}

	private void HideNarrative()
	{
		if(!showMsgs) return;
		for(int i = 0; i < msgs.Count; i++)
			msgs[i].SetActive(false);
	}

	private IEnumerator SpawnPickable()
	{
		GameObject mainPrefab = mainPickable == PickableType.Hope ? hopePrefab : traumaPrefab;
		GameObject antiPrefab = mainPickable == PickableType.Hope ? traumaPrefab : hopePrefab;

		while(true)
		{
			if(mainOn)
			{
				Instantiate(mainPrefab, transform.position, Quaternion.identity, floor);
				coolDown = Mathf.Max(coolDown - 0.1f, 0.5f);
			}
			if(antiOn)
			{
				GameObject pickable = Instantiate(antiPrefab, transform.position, Quaternion.identity, floor);
				pickable.GetComponent<Pickable>().antigenerated = true;
			}
			yield return new WaitForSeconds(coolDown);
		}
	}
}
