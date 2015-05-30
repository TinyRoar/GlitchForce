﻿using UnityEngine;

public class Player : MonoBehaviour
{

    public enum PlayerID
    {
        None,
        Player1,
        Player2
    }

    public PlayerID ThisPlayer;

    public Config.Direction CurrentDirection = Config.Direction.Right;

    public Config.State CurrentState = Config.State.Standing;

    public bool isInvincible = false;
	
    public Animator Hero { get; private set; }

    void Start()
    {
        Hero = this.transform.FindChild("hero").GetComponent<Animator>();
    }


}
