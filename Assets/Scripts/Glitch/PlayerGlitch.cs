using UnityEngine;
using System.Collections;

public class PlayerGlitch : Glitch
{
    public enum PlayerGlitchType
    {
        None,
        Gravity,
        Jump,
        Speed,
        Duplicate,
        AutoMove,
        Invincible,
        Invisible,
    }

    public PlayerGlitchType CurrentType = PlayerGlitchType.None;

    public override void Execute(GameObject player)
    {
        switch (CurrentType)
        {
            case PlayerGlitchType.Gravity:
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                break;
            case PlayerGlitchType.Jump:
                player.GetComponent<Jump>().StartGlitchJump();
                break;
            case PlayerGlitchType.Speed:
                player.GetComponent<Movement>().StartGlitchMovement();
                break;
            case PlayerGlitchType.Duplicate:
                break;
            case PlayerGlitchType.AutoMove:
                break;
            case PlayerGlitchType.Invincible:
                break;
            case PlayerGlitchType.Invisible:
                break;
        }
    }

    public override void End(GameObject player)
    {

        switch (CurrentType)
        {
            case PlayerGlitchType.Jump:
                player.GetComponent<Jump>().StopGlitchJump();
                break;
            case PlayerGlitchType.Speed:
                player.GetComponent<Movement>().StopGlitchMovement();
                break;
            case PlayerGlitchType.Duplicate:
                break;
            case PlayerGlitchType.AutoMove:
                break;
            case PlayerGlitchType.Invincible:
                break;
            case PlayerGlitchType.Invisible:
                break;
        }
    }

}
