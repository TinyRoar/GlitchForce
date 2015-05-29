using UnityEngine;
using System;

public class Updater : MonoBehaviour
{

    private static Updater _instance;
    public static Updater Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        _instance = this;
    }


    public event Action OnUpdate;

	void Update ()
    {
        if (OnUpdate != null)
        {
            OnUpdate();
        }
	}

}
