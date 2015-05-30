using UnityEngine;
using System.Collections;

public class PlayerGlitch : Glitch
{
    public enum PlayerGlitchType
    {
        None,
        PlayerGravity,
        PlayerJump,
        PlayerSpeed
    }

    public PlayerGlitchType CurrentType = PlayerGlitchType.None;

    public override void Execute(GameObject player)
    {
        Debug.Log(player);
        switch (CurrentType)
        {
            case PlayerGlitchType.PlayerGravity:
                Debug.Log(player.GetComponent<Rigidbody2D>());
                
                player.GetComponent<Rigidbody2D>().gravityScale *= -1;
                Debug.Log(player.GetComponent<Rigidbody2D>().gravityScale);
                break;
            case PlayerGlitchType.PlayerJump:
                player.GetComponent<Jump>().StartGlitchJump();
                break;
            case PlayerGlitchType.PlayerSpeed:
                player.GetComponent<Movement>().StartGlitchMovement();
                break;
        }
    }

    public override void End(GameObject player)
    {

        switch (CurrentType)
        {
            case PlayerGlitchType.PlayerJump:
                player.GetComponent<Jump>().StopGlitchJump();
                break;
            case PlayerGlitchType.PlayerSpeed:
                player.GetComponent<Movement>().StopGlitchMovement();
                break;
        }
    }

}
