using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneMenu : Menu
{
    private PlayerManager playerManager;
    private List<GameObject> hearts;
    [SerializeField] GameObject heartPrefab;

    private void Start()
    {
        playerManager = PlayerManager.Instance;
        hearts = new List<GameObject>();

        // Get the height of the canvas
        RectTransform canvasRectTransform = GetComponent<RectTransform>();
        float canvasHeight = canvasRectTransform.rect.height;
        float heartHeight = 60f;

        for (int i = 0; i < playerManager.maxHealth; i++)
        {
            GameObject heart = Instantiate(heartPrefab, this.gameObject.transform, false);

            // Calculate the y-position relative to the top of the canvas
            float yPos = canvasHeight;

            heart.GetComponent<RectTransform>().position = new Vector3(60 + 80 * i, yPos + heartHeight / 2);
            hearts.Add(heart);
        }
    }

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

    public void UpdateHearts()
    {
        for (int i = 0; i < playerManager.maxHealth; i++)
        {
            if (i < playerManager.currentHealth)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
