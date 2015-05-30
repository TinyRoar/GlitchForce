using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    private float speed;
    private Player player;
    private bool speedGlitchActive;
    private float glitchSpeed = 3;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Player>();
        speed = Config.Instance.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        //Spieler 1
        if (Input.GetKey(KeyCode.A) && player.ThisPlayer == Player.PlayerID.Player1)
        {
            transform.position -= new Vector3(speed * (speedGlitchActive ?  glitchSpeed : 1), 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && player.ThisPlayer == Player.PlayerID.Player1)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        //Spieler 2
        if (Input.GetKey(KeyCode.LeftArrow) && player.ThisPlayer == Player.PlayerID.Player2)
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow) && player.ThisPlayer == Player.PlayerID.Player2)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }

    internal void StartGlitchMovement()
    {
        speedGlitchActive = true;
    }

    internal void StopGlitchMovement()
    {
        speedGlitchActive = false;
    }
}
