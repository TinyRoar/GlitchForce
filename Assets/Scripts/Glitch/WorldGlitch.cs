using UnityEngine;
using System.Collections;

public class WorldGlitch : Glitch
{

    public enum WorldGlitchType
    {
        None,
        ObjectGravity,
        RotorTime,
        BoxCollision
    }

    public WorldGlitchType CurrentType = WorldGlitchType.None;

    public override void Execute(GameObject player)
    {
        switch (CurrentType)
        {
            case WorldGlitchType.ObjectGravity:
                GameObject[] gravityObjects = GameObject.FindGameObjectsWithTag("Object");
                foreach (GameObject obj in gravityObjects)
                {
                    obj.GetComponent<Rigidbody2D>().gravityScale *= -1;
                }
                break;

            case WorldGlitchType.RotorTime:
                break;

            case WorldGlitchType.BoxCollision:
                GameObject[] BoxCollisionObjects = GameObject.FindGameObjectsWithTag("Object");
                foreach (GameObject obj in BoxCollisionObjects)
                {
                    obj.GetComponent<Rigidbody2D>().gravityScale = 0;
                    obj.GetComponent<BoxCollider2D>().isTrigger = true;
                }
                break;
        }
    }

    public override void End(GameObject player)
    {
        switch (CurrentType)
        {
            case WorldGlitchType.ObjectGravity:
                break;
            case WorldGlitchType.BoxCollision:
                GameObject[] BoxCollisionObjects = GameObject.FindGameObjectsWithTag("Object");
                foreach (GameObject obj in BoxCollisionObjects)
                {
                    obj.GetComponent<Rigidbody2D>().gravityScale = 1;
                    obj.GetComponent<BoxCollider2D>().isTrigger = false;
                }
                break;
        }
    }

}
