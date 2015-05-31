using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    public float timeToGoBackToMenu;
    private float currentTime;

	// Use this for initialization
	void Start () {
        currentTime = timeToGoBackToMenu;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            SceneCrossConfig.Instance.CurrentSceneID = 0;
            Application.LoadLevel(0);
        }
	}
}
