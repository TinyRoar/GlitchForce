using UnityEngine;
using System.Collections;

public abstract class Glitch : MonoBehaviour
{
    public Texture2D glitchImage;

	// Use this for initialization
	void Start () {
	
	}

    public abstract void Execute(GameObject player);
    public abstract void End(GameObject player);



}
