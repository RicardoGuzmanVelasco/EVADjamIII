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
		Debug.Log(collision.tag);
	}


}
