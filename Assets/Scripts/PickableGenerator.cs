using System.Collections;
using UnityEngine;

public class PickableGenerator : MonoBehaviour
{
	public Transform floor;

	private float time;
	private bool mainOn = false, antiOn = false;

	public PickableType mainPickable;
	public GameObject hopePrefab, traumaPrefab;

	private float coolDown = 5;

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
		else if(time > 20)
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
		else if(time > 17)
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
		else if(time > 15)
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
		else if(time > 10)
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
		else if(time > 5)
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
		#endregion
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
