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
    public int CurrentSceneID = 0;


}
