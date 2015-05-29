using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new() {

    private static T instance;

    public static T Instance
    {
        get
        {
            return instance;
        }
    }

	// Use this for initialization
	void Awake () {
        instance = this as T;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
