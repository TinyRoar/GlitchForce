using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlitchDisplayer : Singleton<GlitchDisplayer> {
    
    public Texture2D globalGlitchImage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if(globalGlitchImage != null)
        GUI.Box(new Rect(Screen.width / 2 - Screen.width / 20, 0, Screen.width / 10, Screen.width / 10), globalGlitchImage);
    }
}
