using UnityEngine;
using System.Collections;

public class GlitchCollector : MonoBehaviour {

    private GlitchMock lastSelectedGlitch;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Glitch")
        {
            Destroy(other.gameObject);
        }
    }

    private void CollectGlitch(GlitchMock mock)
    {

    }
}
