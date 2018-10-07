using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public int Balancement { get; private set; }
	public Slider hopeSlider, traumaSlider;
	public List<AudioSource> audioLayers;

	public void Start()
	{
		Balancement = 0;
	}

	public void Increase(int value)
	{
		Balancement = Mathf.Clamp(Balancement + value, -10, +10);
		hopeSlider.value = Balancement > 0 ? Balancement : 0;
		traumaSlider.value = Balancement < 0 ? Mathf.Abs(Balancement) : 0;

		ScoreChangeEvent();
	}

	private void ScoreChangeEvent()
	{
		switch(Balancement)
		{
			case -1:
			case -2:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = (i == 4) ? false : true;
				break;
			case -3:
			case -4:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = (i >= 4 && i < 6) ? false : true;
				break;
			case -5:
			case -6:
			case -7:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = (i >= 4 && i < 7) ? false : true;
				break;
			case -8:
			case -9:
			case -10:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = (i >= 4 && i < 8) ? false : true;
				break;
			case 0:
			case 1:
			case 2:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = (i == 0) ? false : true;
				break;
			case 3:
			case 4:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = i < 2 ? false : true;
				break;
			case 5:
			case 6:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = i < 3 ? false : true;
				break;
			case 7:
			case 8:
			case 9:
			case 10:
				for(int i = 0; i < audioLayers.Count; i++)
					audioLayers[i].mute = i < 4 ? false : true;
				break;
			default:
				break;
		}
	}
}
