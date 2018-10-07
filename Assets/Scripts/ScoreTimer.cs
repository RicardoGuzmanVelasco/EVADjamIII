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
		int result = player.GetComponent<Score>().Balancement;
		GetComponent<AudioSource>().clip = result >= 0 ? win : lose;
		GetComponent<AudioSource>().Play();
		if(result >= 0)
			winAnimation.SetActive(true);
		else
			loseAnimation.SetActive(true);


	}
}
