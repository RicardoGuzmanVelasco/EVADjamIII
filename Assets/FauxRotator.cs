using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxRotator : MonoBehaviour
{
	public GameObject planet;
	public GameObject character;
	public float speed;

	private void Update()
	{
		planet.transform.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * speed * Input.GetAxis("Movement"));
	}


}
