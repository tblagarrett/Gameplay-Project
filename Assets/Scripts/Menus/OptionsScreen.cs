using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : Menu
{
    [SerializeField] private GameObject mouseToggleSprite;
    [SerializeField] private Sprite buttonUp;
    [SerializeField] private Sprite buttonDown;
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Image brightnessOverlay;
    public override void OpenMenu()
    {
        base.OpenMenu();
        Cursor.lockState = CursorLockMode.None;
    }

    public override void CloseMenu()
    {
        base.CloseMenu();
        Cursor.lockState = CursorLockMode.None;
    }

    public void swapMouseVisibility()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            mouseToggleSprite.GetComponent<Image>().sprite = buttonDown;
        }
        else
        {
            Cursor.visible = true;
            mouseToggleSprite.GetComponent<Image>().sprite = buttonUp;
        }
    }

    public void changeBrightness()
    {
        brightnessOverlay.color = new Color(brightnessOverlay.color.r, brightnessOverlay.color.g, brightnessOverlay.color.b, 1 - brightnessSlider.value);
    }
}