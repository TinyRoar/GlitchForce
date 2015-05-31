using UnityEngine;
using System.Collections;

public class BlueScreen : MonoBehaviour
{
    public float TimeFadeOut = 3.0f;
    private float aTimer = 0;

	// Use this for initialization
	void Start ()
	{
	    Updater.Instance.OnUpdate += DoUpdate;
	}

    private void DoUpdate()
    {
        aTimer += Time.deltaTime;

        if (aTimer >= TimeFadeOut)
        {
            this.gameObject.SetActive(false);
            Updater.Instance.OnUpdate -= DoUpdate;
        }

    }
}
