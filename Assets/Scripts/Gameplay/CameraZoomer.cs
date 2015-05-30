using UnityEngine;
using System.Collections;

public class CameraZoomer : MonoBehaviour {
    private Transform player1;
    private Transform player2;

    public float maximumDistance;

    private MeshRenderer[] borderRenderers = new MeshRenderer[4];

    public float minimumFieldOfView;
    public float maxFieldOfView;
    public float speed;
    public float negativeSpeed;
    bool playersAreVisible = true;


	// Use this for initialization
	void Start () {
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;

        borderRenderers[0] = player1.FindChild("BorderRenderer").GetComponent<MeshRenderer>();
        borderRenderers[1] = player1.FindChild("BorderRenderer 1").GetComponent<MeshRenderer>();
        borderRenderers[2] = player2.FindChild("BorderRenderer").GetComponent<MeshRenderer>();
        borderRenderers[3] = player2.FindChild("BorderRenderer 1").GetComponent<MeshRenderer>();
	}

    void Update()
    {
        Vector2 middleVec = GetMiddleBewteenPlayers();
        transform.position = new Vector3(middleVec.x, transform.position.y, transform.position.z);
    }

	// Update is called once per frame
	public void ZoomCam (Movement movement) {
        playersAreVisible = true;
        
        foreach(MeshRenderer renderer in borderRenderers)
        {
            if(!renderer.IsVisibleFrom(Camera.main))
            {
                Camera.main.fieldOfView+= speed;
                playersAreVisible = false;
                break;
            }
        }

        if(Camera.main.fieldOfView > maxFieldOfView)
        {
            if(movement.player.CurrentDirection == Config.Direction.Left)
            {
                if (movement.player.transform.position.x < Camera.main.transform.position.x)
                {
                    movement.transform.position = movement.lastPosition;
                }
            }

            else if(movement.player.CurrentDirection == Config.Direction.Right)
            {
                if (movement.player.transform.position.x > Camera.main.transform.position.x)
                {
                    movement.transform.position = movement.lastPosition;
                }
            }

        }

        if(playersAreVisible && Camera.main.fieldOfView > minimumFieldOfView)
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
