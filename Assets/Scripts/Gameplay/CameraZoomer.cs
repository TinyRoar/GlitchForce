using UnityEngine;
using System.Collections;

public class CameraZoomer : MonoBehaviour {
    public Transform player1;
    public Transform player2;

    public float maximumDistance;

    public MeshRenderer[] borderRenderers;

    public float minimumFieldOfView;
    public float speed;
    public float negativeSpeed;
    bool playersAreVisible = true;
    private float toSmallView;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 middleVec = GetMiddleBewteenPlayers();
        transform.position = new Vector3(middleVec.x, transform.position.y, transform.position.z);
        playersAreVisible = true;
        foreach(MeshRenderer renderer in borderRenderers)
        {
            if(!renderer.IsVisibleFrom(Camera.main))
            {
                Debug.Log("Pos");
                toSmallView = Camera.main.fieldOfView;
                Camera.main.fieldOfView+= speed;
                playersAreVisible = false;
                break;
            }
        }

        if(playersAreVisible && Camera.main.fieldOfView > minimumFieldOfView && Camera.main.fieldOfView > toSmallView + 1)
        {
            Camera.main.fieldOfView-= negativeSpeed;
        }
       
	}

    private Vector2 GetMiddleBewteenPlayers()
    {
        Vector3 player1Pos = player1.position;
        Vector3 player2Pos = player2.position;

        float smallerX = player1Pos.x < player2Pos.x ? player2Pos.x:player1Pos.x;
        float smallerY = player1Pos.y < player2Pos.y ? player2Pos.y : player1Pos.y;
        float biggerX = smallerX == player1Pos.x ? player2Pos.x : player1Pos.x;
        float biggerY = smallerY == player1Pos.y ? player2Pos.y : player1Pos.y;


        return new Vector2(smallerX + getDiff(biggerX, smallerX) / 2, smallerY + getDiff(biggerY, smallerY) / 2);
    }

    private float getDiff(float val1, float val2)
    {
        return val1 - val2;
    }

    
}
