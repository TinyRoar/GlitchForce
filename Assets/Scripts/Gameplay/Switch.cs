using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{

    public GameObject ObjectToDestroy;

	public enum SwitchState {
		None,
		Destroy,
		Visible
	}
	public SwitchState CurrentSwitchState;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			switch(CurrentSwitchState)
			{
			case SwitchState.Destroy:
            	GameObject.Destroy(ObjectToDestroy);
				break;
			case SwitchState.Visible:
				ObjectToDestroy.SetActive(true);
				break;

			}
        }
    }


}
