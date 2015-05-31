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
        Collision
    }

    public PlayerGlitchType CurrentType = PlayerGlitchType.None;
    public bool destroyOnDrop = true;

    public override void Execute(GameObject player)
    {
        SoundManager.Instance.Play("Glitch_Collect");
        switch (CurrentType)
        {
            case PlayerGlitchType.Collision:
                player.layer = LayerMask.NameToLayer("PlayerNoCollision");
                break;
            case PlayerGlitchType.Gravity:
                player.GetComponent<Jump>().StopJump();
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                player.GetComponent<Player>().SignInUpdate();
                player.GetComponent<Movement>().AllowMoving = false;
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
                player.GetComponent<Movement>().StartAutoMove();
                break;
            case PlayerGlitchType.Invincible:
                player.GetComponent<Player>().isInvincible = true;
                break;
        }
    }

    public override void End(GameObject player)
    {
        SoundManager.Instance.Play("Glitch_Drop");
        switch (CurrentType)
        {
            case PlayerGlitchType.Collision:
                player.layer = LayerMask.NameToLayer("Player");
                break;
            case PlayerGlitchType.Gravity:
                Updater.Instance.OnUpdate += player.GetComponent<Player>().DoFallingUpdate;
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                break;
            case PlayerGlitchType.Jump:
                player.GetComponent<Jump>().StopGlitchJump();
                break;
            case PlayerGlitchType.Speed:
                player.GetComponent<Movement>().StopGlitchMovement();
                break;
            case PlayerGlitchType.AutoMove:
                player.GetComponent<Movement>().StopAutoMove();
                break;
            case PlayerGlitchType.Invincible:
                player.GetComponent<Player>().isInvincible = false;
                break;
        }
    }


}
