using UnityEngine;
using System.Collections;

public class WorldGlitch : Glitch
{

    public enum WorldGlitchType
    {
        None,
        ObjectGravity
    }

    public WorldGlitchType CurrentType = WorldGlitchType.None;

    public override void Execute(GameObject player)
    {
        switch (CurrentType)
        {
            case WorldGlitchType.ObjectGravity:
                GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
                foreach (GameObject obj in objects)
                {
                    obj.GetComponent<Rigidbody2D>().gravityScale *= -1;
                }
                break;
        }
    }
}
