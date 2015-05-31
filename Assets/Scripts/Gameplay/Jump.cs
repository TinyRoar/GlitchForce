using System.Reflection;
using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{

    private float jumpHeight;
    private float jumpWidth;
    private Player player;

    private float defaultTime = 1.0f;
    private float jumpTime;
    private float gravity = 1;
    public bool AllowJumping = true;
    //private Vector3 jumpStartPos;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Player>();

        jumpHeight = Config.Instance.JumpHeight;
        jumpWidth = Config.Instance.JumpWidth;
		defaultTime = Config.Instance.JumpSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player1 && AllowJumping == true)
        {
            StartJump();
        }
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.UpArrow)) && player.CurrentState != Config.State.Jumping && player.ThisPlayer == Player.PlayerID.Player2 && AllowJumping == true)
        {
            StartJump();
        }

    }

    private void StartJump()
    {
        SoundManager.Instance.Play("Jump");
        player.CurrentState = Config.State.Jumping;
        jumpTime = defaultTime;
        gravity = this.GetComponent<Rigidbody2D>().gravityScale;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.player.Hero.Play("JumpUp");
        //this.jumpStartPos = this.transform.position;
    }

    public void StopJump()
    {
        if (player.CurrentState != Config.State.Jumping)
            return;

        player.CurrentState = Config.State.Standing;
        this.GetComponent<Rigidbody2D>().gravityScale = gravity;
        this.player.Hero.Play("JumpLand");
        SoundManager.Instance.Play("On_Collision");
    }

    private void DoJump()
    {
        if (player.CurrentState != Config.State.Jumping)
            return;

        if (AllowJumping == false)
            return;

        jumpTime -= Time.deltaTime;
        Vector3 pos = this.transform.position;
        //Vector3 pos = this.jumpStartPos;

        pos.y += jumpHeight * jumpTime * gravity * Time.deltaTime;
        pos.x += jumpWidth / 10.0f * Time.deltaTime * (int)player.CurrentDirection;
        this.transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (player.CurrentState == Config.State.Jumping)
        {
            StopJump();
        }
    }

    public void StartGlitchJump()
    {
        SoundManager.Instance.Play("Glitch_Jump");
        jumpHeight = Config.Instance.JumpGlitchHeight;
        jumpWidth = Config.Instance.JumpGlitchWidth;
    }

    public void StopGlitchJump()
    {
        jumpHeight = Config.Instance.JumpHeight;
        jumpWidth = Config.Instance.JumpWidth;
    }

}
