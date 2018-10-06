using UnityEngine;

public class Weapon : MonoBehaviour
{
	public PickableType type;
	private Player player;

	private void Awake()
	{
		player = GetComponentInParent<Player>();
	}


	public void Hunt(PickableType pickableType)
	{
		player.Impact(pickableType, type);
	}
}
