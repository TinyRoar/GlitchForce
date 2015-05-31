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
        Debug.Log("Player inside");

        if (other.tag == "Player" && other.GetComponent<Player>().isInvincible == false)
        {
            this.playerDead++;
            Debug.Log("Player dead");

            if(this.playerDead >= this.playerCount)
            {
                SoundManager.Instance.Play("Game Over");
                DieArea.RestartLevel();
            }
        }
    }

    public static void RestartLevel()
    {
        Application.LoadLevel(SceneCrossConfig.Instance.CurrentSceneID);
    }
}
