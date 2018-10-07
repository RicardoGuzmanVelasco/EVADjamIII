using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
	public int maxTime;
	public Player player;
	public Text timerText;
	private float time;

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
		Debug.Log(player.GetComponent<Score>().Balancement);
	}
}
