using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour
{
    public void OnChangeScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
