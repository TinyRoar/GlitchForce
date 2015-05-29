using UnityEngine;
using System.Collections;

public class SceneFinish : MonoBehaviour
{

    public static int playerInFinisher = 0;
    public static int playerCount = 2;

	// Use this for initialization
	void Start () {
	

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SceneFinish")
        {
            SceneFinish.playerInFinisher++;
            Debug.Log("Player go in Finish");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "SceneFinish")
        {
            SceneFinish.playerInFinisher--;
            Debug.Log("Player leave in Finish");
        }
    }

    private void CheckFinish()
    {
        if (SceneFinish.playerInFinisher >= SceneFinish.playerCount)
        {
            Config.Instance.CurrentSceneID++;
            Application.LoadLevel(Config.Instance.CurrentSceneID);
        }
    }


}
