using UnityEngine;
using System.Collections;

public class SceneFinish : MonoBehaviour
{

    private int playerInFinisher = 0;
    private int playerCount = 1;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher++;
            Debug.Log("Player go in Finish");
            this.CheckFinish();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher--;
            Debug.Log("Player leave in Finish");
            this.CheckFinish();
        }
    }

    private void CheckFinish()
    {
        if (this.playerInFinisher >= this.playerCount)
        {
            SceneCrossConfig.Instance.CurrentSceneID++;
            Application.LoadLevel(SceneCrossConfig.Instance.CurrentSceneID);
        }
    }


}
