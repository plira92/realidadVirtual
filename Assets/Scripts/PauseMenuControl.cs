using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControl : MonoBehaviour
{
    public GameObject pauseMenu;

    public void ShowOrHidePauseMenu()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);
    }
}
