﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public enum PlayerID
    {
        None,
        Player1,
        Player2
    }

    public PlayerID ThisPlayer;

	void Start ()
	{
	    //Config.Instance.Speed

	    Updater.Instance.OnUpdate += DoUpdate;

	    GameEvents.Instance.OnKeyUp += OnKeyUp;

	}

    void OnKeyUp(KeyCode key)
    {
        Debug.Log("key " + key.ToString() + " pressed");
    }

    void DoUpdate()
    {
        // Update
    }

}
