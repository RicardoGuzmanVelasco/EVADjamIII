using System.Collections;
using UnityEngine;

public class PickableGenerator : MonoBehaviour
{
	public Transform floor;

	public PickableType mainPickable;

	public GameObject hopePrefab, traumaPrefab;

	private float coolDown = 5;

	private void Start()
	{
		StartCoroutine(SpawnPickable());
	}

	private IEnumerator SpawnPickable()
	{
		GameObject prefab = mainPickable == PickableType.Hope ? hopePrefab : traumaPrefab;

		while(true)
		{
			GameObject pickable = Instantiate(prefab, transform.position, Quaternion.identity, floor);

			coolDown = Mathf.Max(coolDown - 0.1f, 0.5f);

			yield return new WaitForSeconds(coolDown);
		}
	}
}
