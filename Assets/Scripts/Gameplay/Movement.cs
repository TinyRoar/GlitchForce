﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    private float speed;
    private Player player;
    private bool speedGlitchActive;
    private float glitchSpeed = 3;
    [HideInInspector]
    public Vector3 lastPosition;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Player>();
        speed = Config.Instance.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Spieler 1
        if (Input.GetKey(KeyCode.A) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player1)
        {
            lastPosition = transform.position;
            transform.position -= new Vector3(speed * (speedGlitchActive ?  glitchSpeed : 1), 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Left;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
        }

        if (Input.GetKey(KeyCode.D) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player1)
        {
            lastPosition = transform.position;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Right;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
        }

        // Spieler 2
        if (Input.GetKey(KeyCode.LeftArrow) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player2)
        {
            lastPosition = transform.position;
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Left;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
        }

        if (Input.GetKey(KeyCode.RightArrow) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player2)
        {
            lastPosition = transform.position;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Right;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
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
