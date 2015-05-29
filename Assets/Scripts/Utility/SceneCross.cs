using UnityEngine;
using System.Collections;

public class SceneCross : MonoBehaviour {

    private static SceneCross _instance = null;
    public static SceneCross Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

}
