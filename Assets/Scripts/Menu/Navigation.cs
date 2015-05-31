using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour
{
    public void StartGame()
    {
        SceneCrossConfig.Instance.CurrentSceneID++;
        Application.LoadLevel(SceneCrossConfig.Instance.CurrentSceneID);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
