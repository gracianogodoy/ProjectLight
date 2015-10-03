using UnityEngine;
using System.Collections;

public class GameMenuControl : MonoBehaviour
{
    public GameObject Menu;

    public void ToggleMenu(bool value)
    {
        Menu.SetActive(value);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu(!Menu.activeInHierarchy);
        }

        if (Menu.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
    }
}
