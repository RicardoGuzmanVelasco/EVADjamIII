using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
	public int maxTime;
	public Player player;
	public Text timerText;
	private float time;

	public GameObject winAnimation, loseAnimation;

	public AudioClip win, lose;
	public AudioSource endSound;

	private void Start()
	{
		time = 0.0f;
		timerText.text = FormatTime();
	}

	private string FormatTime()
	{
		TimeSpan span = new TimeSpan(0, 0, maxTime - (int)time);
		return "0" + span.Minutes + ":" + (span.Seconds < 10 ? "0" : "") + span.Seconds;
	}

	private void Update()
	{
		time += Time.deltaTime;
		timerText.text = FormatTime();

		if(time >= maxTime)
			ToEnd();
	}

	private void ToEnd()
	{
		timerText.text = "";
		Time.timeScale = 0;
		int result = player.GetComponent<Score>().Balancement;
		endSound.PlayOneShot(result >= 0 ? win : lose);
		if(result >= 0)
			winAnimation.SetActive(true);
		else
			loseAnimation.SetActive(true);
		winAnimation.transform.parent.gameObject.SetActive(true);
		player.transform.GetComponent<Score>().Mute();
		Destroy(this);
	}
}
