using UnityEngine;
using System.Collections;

public class SceneFinish : MonoBehaviour
{

    private int playerInFinisher = 0;
    private int playerCount = 4;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher++;
            this.CheckFinish();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher--;
            this.CheckFinish();
        }
    }

    private void CheckFinish()
    {
        if (this.playerInFinisher >= this.playerCount)
        {
            Debug.Log(SceneCrossConfig.Instance.CurrentSceneID);
            SceneCrossConfig.Instance.CurrentSceneID++;
            //Debug.Log(SceneCrossConfig.Instance.CurrentSceneID);
            Application.LoadLevel(SceneCrossConfig.Instance.CurrentSceneID);
        }
    }


}
