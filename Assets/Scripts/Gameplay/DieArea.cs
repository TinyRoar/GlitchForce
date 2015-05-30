using UnityEngine;
using System.Collections;

public class DieArea : MonoBehaviour
{
    private int playerDead = 0;
    private int playerCount = 1;

	void Start ()
    {
	
	}

    //Erst wenn beide Spieler tod sind, wird das Spiel neu gestartet
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.playerDead++;
            Debug.Log("Player dead");

            if(this.playerDead >= this.playerCount)
            {
                this.RestartLevel();
            }
        }
    }

    private void RestartLevel()
    {
        Application.LoadLevel(SceneCrossConfig.Instance.CurrentSceneID);
    }
}
