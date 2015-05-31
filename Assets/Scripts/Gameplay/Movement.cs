using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

    private float speed;
    [HideInInspector]
    public Player player;
    private bool speedGlitchActive;
    private float glitchSpeed = 3;
    [HideInInspector]
    public Vector3 lastPosition;

    private bool IsAutoMoving = false;

    private bool IsMoving = false;

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
        if (
            (
                ((Input.GetKey(KeyCode.A) || Input.GetAxis("Player1X") < -0.9f) && IsAutoMoving == false)
                && player.ThisPlayer == Player.PlayerID.Player1
                )
            ||
            (
                ((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Player2X") < -0.9f) && IsAutoMoving == false)
                && player.ThisPlayer == Player.PlayerID.Player2
                )
            )
        {
            lastPosition = transform.position;
            transform.position -= new Vector3(speed * (speedGlitchActive ? glitchSpeed : 1), 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Left;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
            if (player.CurrentState == Config.State.Standing)
                this.player.Hero.Play("Run");
            IsMoving = true;
        }
        else if (
                (
                    (Input.GetKey(KeyCode.D) || Input.GetAxis("Player1X") > 0.9f || IsAutoMoving == true)
                    && player.ThisPlayer == Player.PlayerID.Player1
                )
            ||
                (
                    (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Player2X") > 0.9f|| IsAutoMoving == true)
                    && player.ThisPlayer == Player.PlayerID.Player2
                )
            )
        {
            lastPosition = transform.position;
            transform.position += new Vector3(speed * (speedGlitchActive ? glitchSpeed : 1), 0, 0) * Time.deltaTime;
            player.CurrentDirection = Config.Direction.Right;
            Camera.main.GetComponent<CameraZoomer>().ZoomCam(this);
            if (player.CurrentState == Config.State.Standing)
                this.player.Hero.Play("Run");
            IsMoving = true;
        }
        // Moving was last frame, but was stopped this Frame
        else if (IsMoving == true)
        {
            if (player.CurrentState == Config.State.Standing)
                this.player.Hero.Play("Idle");
            IsMoving = false;
        }

        if(player.CurrentDirection != player.LastDirection)
        {
            transform.Rotate(0, 180, 0);
        }

        player.LastDirection = player.CurrentDirection;
    }

    internal void StartGlitchMovement()
    {
        speedGlitchActive = true;
    }

    internal void StopGlitchMovement()
    {
        speedGlitchActive = false;
    }

    // Glitch AutoMove
    internal void StartAutoMove()
    {
        this.IsAutoMoving = true;
    }

    internal void StopAutoMove()
    {
        this.IsAutoMoving = false;
    }

    // JumpFall Animation if Player fall down
    private int groundedCount = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        groundedCount++;
        if (IsMoving == false)
            this.player.Hero.Play("Idle");
        if (player.CurrentState == Config.State.Falling)
            player.CurrentState = Config.State.Standing;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        groundedCount--;
        if (groundedCount == 0)
        {
            if (player.CurrentState != Config.State.Jumping)
            {
                player.CurrentState = Config.State.Falling;
                this.player.Hero.Play("JumpFall");
            }
        }
    }

}
