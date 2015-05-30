using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{

    public GameObject ObjectToDestroy;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Destroy(ObjectToDestroy);
        }
    }


}
