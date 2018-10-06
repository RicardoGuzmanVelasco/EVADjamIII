using UnityEngine;

public class FauxRotator : MonoBehaviour
{
	public Transform planetFloor;
	public GameObject character;
	private Animator characterAnimator;
	public float speed = 10f;

	private int lastMovementInput = 0;

	private void Awake()
	{
		characterAnimator = character.GetComponentInChildren<Animator>();
	}

	private void FixedUpdate()
	{
		int currentInput = Input.GetAxis("Movement") > 0 ? 1 : Input.GetAxis("Movement") < 0 ? -1 : 0;

		planetFloor.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * speed * currentInput);


		if(currentInput == lastMovementInput)
			return;
		
		if(currentInput < 0)
			characterAnimator.SetTrigger("ToFront");
		else if(currentInput > 0)
			characterAnimator.SetTrigger("ToBack");
		else if(!Input.GetButtonDown("Movement"))
			characterAnimator.SetTrigger("Stop");

		lastMovementInput = currentInput;
	}

}
