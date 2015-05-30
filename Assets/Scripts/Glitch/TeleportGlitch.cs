using UnityEngine;
using System.Collections;

public class TeleportGlitch : PlayerGlitch {
    
    private Transform pointToTeleportTo;

    public override void Execute(GameObject player)
    {
        player.transform.position = pointToTeleportTo.position;
    }

    public override void End(GameObject player)
    {
    }
	// Use this for initialization
	void Start () {
        pointToTeleportTo = transform.FindChild("PointToTeleportTo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
