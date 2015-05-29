using UnityEngine;
using System.Collections;

public class GlitchCollector : MonoBehaviour {
    
    private GlitchMock selectedGlitch;
    private GameObject selectedGlitchGameObject;
    private string lastSelectedGlitchGameObject = "";

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Glitch" && lastSelectedGlitchGameObject == "")
        {
            Debug.Log(lastSelectedGlitchGameObject);
            if (selectedGlitch != null)
            {
                if (selectedGlitch is PlayerGlitchMock)
                {
                    DropPlayerGlitch(other.transform.position);
                    lastSelectedGlitchGameObject = other.gameObject.name;
                }
                else
                {
                    DropGlobalGlitch();
                }
            }
            CollectGlitch(other.GetComponent<GlitchMock>());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Glitch")
        {
            Debug.Log("Exit");
            lastSelectedGlitchGameObject = "";
        }
    }

    private void CollectGlitch(GlitchMock mock)
    {
        selectedGlitch = mock;
        mock.gameObject.SetActive(false);
        selectedGlitchGameObject = mock.gameObject;
    }

    private void DropPlayerGlitch(Vector3 position)
    {
        selectedGlitchGameObject.SetActive(true);
        selectedGlitchGameObject.transform.position = position;
    }

    private void DropGlobalGlitch()
    {
        selectedGlitchGameObject.SetActive(true);
    }
}
