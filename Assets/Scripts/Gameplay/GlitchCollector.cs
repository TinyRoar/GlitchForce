using UnityEngine;
using System.Collections;

public class GlitchCollector : MonoBehaviour {
    
    private GlitchMock selectedGlitch;
    private GameObject selectedGlitchGameObject;
    public Transform playerGlitchSpawnPoint;

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
            if (selectedGlitch != null)
            {
                if (selectedGlitch is Glitch && other.GetComponent<GlitchMock>() is Glitch)
                {
                    DropPlayerGlitch();
                }
                else if(other.GetComponent<GlitchMock>() is GlobalGlitchMock)
                {
                    DropGlobalGlitch();
                }
            }
            CollectGlitch(other.GetComponent<GlitchMock>());
        }
    }

    private void CollectGlitch(GlitchMock mock)
    {
        selectedGlitch = mock;
        mock.gameObject.SetActive(false);
        selectedGlitchGameObject = mock.gameObject;
    }

    private void DropPlayerGlitch()
    {
        selectedGlitchGameObject.SetActive(true);
        selectedGlitchGameObject.transform.position = playerGlitchSpawnPoint.position;
    }

    private void DropGlobalGlitch()
    {
        selectedGlitchGameObject.SetActive(true);
    }
}
