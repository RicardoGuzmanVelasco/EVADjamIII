using UnityEngine;

public class FauxRotator : MonoBehaviour
{
	public Transform planetFloor;
	public GameObject character;
	private Animator characterAnimator;
	public float speed = 10f;
	public AudioSource footSteps;

	private int lastMovementInput = 0;

	private void Awake()
	{
		characterAnimator = character.GetComponentInChildren<Animator>();
	}

	private void Update()
	{
		int currentInput = Input.GetAxis("Horizontal") > 0 ? 1 : Input.GetAxis("Horizontal") < 0 ? -1 : 0;
		characterAnimator.SetBool("Front", currentInput <= 0);
		planetFloor.RotateAround(Vector3.zero, Vector3.forward, Time.deltaTime * speed * currentInput);


		if(currentInput == lastMovementInput)
			return;

		if(currentInput < 0)
		{
			characterAnimator.SetTrigger("ToFront");
			characterAnimator.SetBool("Stopped", false);
		}
		else if(currentInput > 0)
		{
			characterAnimator.SetTrigger("ToBack");
			characterAnimator.SetBool("Stopped", false);
		}
		else if(!Input.GetButtonDown("Horizontal"))
		{
			characterAnimator.SetTrigger("Stop");
			characterAnimator.SetBool("Stopped", true);
		}

		lastMovementInput = currentInput;


		//Steps region. Working fully.
		if(!characterAnimator.GetBool("Front"))
			footSteps.pitch *= 0.85f;
		else
			footSteps.pitch = 1f;

		if(!characterAnimator.GetBool("Stopped"))
			footSteps.Play();
		else
			footSteps.Stop();

		Debug.Log("Stopped: " + characterAnimator.GetBool("Stopped") + "\t" +
			"Front: " + characterAnimator.GetBool("Front") + "\t" +
			"Current input: " + currentInput + "\t"
			);
	}

}
