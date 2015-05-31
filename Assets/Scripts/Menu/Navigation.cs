using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour
{
    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
