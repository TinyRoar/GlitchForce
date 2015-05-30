using System.Reflection;
using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{

    private float jumpHeight;
    private float jumpWidth;
    private Player player;

    public enum State { standing, running, jumping }
    private State currentState = State.standing;

    private float defaultTime = 1.0f;
    private float jumpTime;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Player>();

        jumpHeight = Config.Instance.JumpHeight;
        jumpWidth = Config.Instance.JumpWidth;
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();

        if (Input.GetKeyDown(KeyCode.Space) && currentState != State.jumping && player.ThisPlayer == Player.PlayerID.Player1)
        {
        StartJump();
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && currentState != State.jumping && player.ThisPlayer == Player.PlayerID.Player2)
        {
            StartJump();
        }

    }

    private void StartJump()
    {
        currentState = State.jumping;
        jumpTime = defaultTime;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void StopJump()
    {
        currentState = State.standing;
        this.GetComponent<Rigidbody2D>().gravityScale = 1;
    }


    private void DoJump()
    {
        if (currentState != State.jumping)
        { return; }

        jumpTime -= Time.deltaTime;
        Vector3 pos = this.transform.position;

        pos.y += jumpHeight / 100.0f * jumpTime;
        pos.x += jumpWidth / 10.0f * Time.deltaTime;
        this.transform.position = pos;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StopJump();
    }

    public void StartGlitchJump()
    {
        jumpHeight = Config.Instance.JumpGlitchHeight;
        jumpWidth = Config.Instance.JumpGlitchWidth;
    }

    public void StopGlitchJump()
    {
        jumpHeight = Config.Instance.JumpHeight;
        jumpWidth = Config.Instance.JumpWidth;
    }

}
