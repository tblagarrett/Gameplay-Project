using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : Menu
{
    public override void OpenMenu()
    {
        base.OpenMenu();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public override void CloseMenu()
    {
        base.CloseMenu();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }
}
