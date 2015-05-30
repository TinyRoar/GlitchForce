using UnityEngine;
using System.Collections;

public class DuplicateGlitch : PlayerGlitch {
    private GameObject playerClone;
    public override void Execute(GameObject player)
    {
        playerClone=Instantiate(player,player.transform.position+new Vector3(-2,0,0),player.transform.rotation)as GameObject;
        Destroy(playerClone.GetComponent<GlitchCollector>());
        playerClone.AddComponent<PlayerClone>();
        playerClone.GetComponent<PlayerClone>().controlingPlayer = player.transform;
    }
    public override void End(GameObject player)
    {
        Destroy(playerClone);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
