using UnityEngine;
using System.Collections;

public class CameraZoomer : MonoBehaviour {
    public Transform player1;
    public Transform player2;

    public float maximumDistance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 middleVec = GetMiddleBewteenPlayers();
        transform.position = new Vector3(middleVec.x, middleVec.y, transform.position.z);
	}

    private Vector2 GetMiddleBewteenPlayers()
    {
        Vector3 player1Pos = player1.position;
        Vector3 player2Pos = player2.position;

        float smallerX = player1Pos.x < player2Pos.x ? player2Pos.x:player1Pos.x;
        float smallerY = player1Pos.y < player2Pos.y ? player2Pos.y : player1Pos.y;

        return new Vector2(smallerX + getDiff(player1Pos.x, player2Pos.x) / 2, smallerY + getDiff(player1Pos.y, player2Pos.y) / 2);
    }

    private float getDiff(float val1, float val2)
    {
        return val1 - val2;
    }
}
