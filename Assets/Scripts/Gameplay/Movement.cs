using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float speed = 1.0f;
    private Player player;

	// Use this for initialization
	void Start ()
    {
        player = this.GetComponent<Player>();
	
    }
	
	// Update is called once per frame
	void Update ()
    {

	    if(Input.GetKey(KeyCode.A) && player.ThisPlayer == Player.PlayerID.Player1)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && player.ThisPlayer == Player.PlayerID.Player1)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        
	}
}
