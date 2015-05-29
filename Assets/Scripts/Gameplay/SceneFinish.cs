using UnityEngine;
using System.Collections;

public class SceneFinish : MonoBehaviour
{

    private int playerInFinisher = 0;
    private int playerCount = 2;

	// Use this for initialization
	void Start () {
	

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher++;
            Debug.Log("Player go in Finish");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerInFinisher--;
            Debug.Log("Player leave in Finish");
        }
    }

    private void CheckFinish()
    {
        if (this.playerInFinisher >= this.playerCount)
        {
            Config.Instance.CurrentSceneID++;
            Application.LoadLevel(Config.Instance.CurrentSceneID);
        }
    }


}
