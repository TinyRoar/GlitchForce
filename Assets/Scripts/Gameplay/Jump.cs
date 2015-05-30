using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{

    private float jumpHeight = 0.5f;
    private float jumpWidth = 0.5f;
    private Player player;

    public enum State { standing, running, jumping }
    public State currentState = State.standing;

    private float defaultTime = 1.0f;
    private float jumpTime;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        DoJump();

    }

    private void StartJump()
    {
        currentState = State.jumping;
        jumpTime = defaultTime;
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void EndJump()
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

        pos.y = jumpHeight * jumpTime;
        Debug.Log(jumpHeight * jumpTime);


        // stop


        //  pos.x = jumpWidth * Time.deltaTime;
        this.transform.position = pos;

    }
}
