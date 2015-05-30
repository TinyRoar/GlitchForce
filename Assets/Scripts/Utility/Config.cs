using System.Globalization;
using UnityEngine;
using System.Collections;

public class Config : Singleton<Config>
{

    private static Config _instance;
    public static Config Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        _instance = this;
    }

    public float Speed = 2.0f;

    public float JumpHeight = 10.0f;
    public float JumpWidth = 5.0f;
    public float JumpGlitchHeight = 20.0f;
    public float JumpGlitchWidth = 8.0f;
	public float JumpSpeed = 8.0f;

    // Internal stuff
    public enum Direction
    {
        None,
        Left = -1,
        Right = 1
    }

    public enum State
    {
        Standing,
        //Running,
        Jumping,
        Falling
    }



}
