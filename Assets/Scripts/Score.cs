using UnityEngine;
using UnityEngine.UI;

public class Score
{
	public int Balancement { get; private set; }
	public Slider hopeSlider, traumaSlider;

	public Score(Slider hopeSlider, Slider traumaSlider)
	{
		this.hopeSlider = hopeSlider;
		this.traumaSlider = traumaSlider;
		Balancement = 0;
	}

	public void Increase(int value)
	{
		Balancement = Mathf.Clamp(Balancement + value, -10, +10);
		hopeSlider.value = Balancement > 0 ? Balancement : 0;
		traumaSlider.value = Balancement < 0 ? Mathf.Abs(Balancement) : 0;
	}
}
