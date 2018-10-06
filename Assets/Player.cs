using System;
using UnityEngine;

public class Player : MonoBehaviour
{
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

	internal void Impact(PickableType pickableType, PickableType type)
	{
		if(pickableType == PickableType.Hope && type == PickableType.Hope)
			Debug.Log("Hope haunted by net!");
	}
}
