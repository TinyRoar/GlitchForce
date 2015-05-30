using UnityEngine;
using System.Collections;

public class GlitchCollector : MonoBehaviour {

    public static WorldGlitch selectedWorldGlitch;
    private PlayerGlitch selectedPlayerGlitch;
    public static GameObject selectedWorldGlitchGameObject;
    private GameObject selectedPlayerGlitchGameObject;
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
            if(other.GetComponent<Glitch>() is PlayerGlitch)
            {
                if(selectedPlayerGlitch != null)
                {
                    selectedPlayerGlitch.End(this.gameObject);
                    if (!selectedPlayerGlitch.DestroyOnDrop)
                    {
                        DropPlayerGlitch();
                    }
                }
            }

            else
            {
                if(selectedWorldGlitch != null)
                {
                    DropWorldGlitch();
                }
            }

            CollectGlitch(other.GetComponent<Glitch>());
        }
    }

    private void CollectGlitch(Glitch glitch)
    {
        glitch.Execute(this.gameObject);
        if(glitch is PlayerGlitch)
        {
            transform.FindChild("GlitchDisplay").GetComponent<MeshRenderer>().material.mainTexture = glitch.glitchImage;
            selectedPlayerGlitch = glitch as PlayerGlitch;
            selectedPlayerGlitchGameObject = glitch.gameObject;
        }

        else
        {
            selectedWorldGlitch = glitch as WorldGlitch;
            selectedWorldGlitchGameObject = glitch.gameObject;
        }
        glitch.gameObject.SetActive(false);
    }

    private void DropPlayerGlitch()
    {
        selectedPlayerGlitchGameObject.SetActive(true);
        selectedPlayerGlitchGameObject.transform.position = playerGlitchSpawnPoint.position;
    }

    private void DropWorldGlitch()
    {
        selectedWorldGlitch.End(this.gameObject);
        selectedWorldGlitchGameObject.SetActive(true);
    }
}
