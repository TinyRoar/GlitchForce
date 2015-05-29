using UnityEngine;
using System.Collections;

public class PlayerGlitch : Glitch
{
    public enum PlayerGlitchType
    {
        None,
        PlayerGravity,
        PlayerJump
    }

    public PlayerGlitchType CurrentType = PlayerGlitchType.None;

    public override void Execute(GameObject player)
    {
        switch (CurrentType)
        {
            case PlayerGlitchType.PlayerGravity:
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                break;
            case PlayerGlitchType.PlayerJump:
                //player.GetComponent<Movement>().DoGlitchJump();
                break;
        }
    }

}
