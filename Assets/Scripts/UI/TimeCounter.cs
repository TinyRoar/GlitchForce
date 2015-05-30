using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour

{
    private float timeCounter;
    public float defaultTime;
    private Text TimerText;

	// Use this for initialization
	void Start ()
    {
        TimerText = this.GetComponent<Text>();
        timeCounter = defaultTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeCounter -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeCounter / 60F);
        int seconds = Mathf.FloorToInt(timeCounter - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        TimerText.text = niceTime;
	}
}
