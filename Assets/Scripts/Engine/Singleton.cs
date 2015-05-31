using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {

    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

	// Use this for initialization
	void Awake () {
	    if (_instance == null)
	    {
            _instance = this as T;
	    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
