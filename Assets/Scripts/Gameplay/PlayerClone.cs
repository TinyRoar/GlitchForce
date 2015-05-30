using UnityEngine;
using System.Collections;

public class PlayerClone : MonoBehaviour {
    public Transform controlingPlayer;
    private Vector3 lastPosition;

	// Use this for initialization
	void Start () {
        lastPosition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Distance(transform.position, controlingPlayer.position) > 2 ? transform.position : lastPosition;
        lastPosition = transform.position;

	
	}
}
