using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameScreen : Menu
{
    [HideInInspector] public PuzzleGrid puzzleGrid;
    private float timer;
    [SerializeField] GameObject timerObj;
    [SerializeField] GameObject noneMenu;
    private bool timerRunning;
    private UIManager uiMan;

    private void Start()
    {
        // Whenever a button is clicked, we run this function
        puzzleGrid = GetComponentInChildren<PuzzleGrid>();
        puzzleGrid.OnButtonClicked += OnButtonClicked;

        uiMan = UIManager.Instance;

        // Minute timer closes the screen when it ends and deals damage to player
        timer = 60f;
        timerRunning = false;
    }

    private void Update()
    {
        if (timerRunning)
        {
            timer -= Time.unscaledDeltaTime;

            if (timer <= 0) {
                uiMan.GoToMenu(GameMenu.None);
                PlayerManager.Instance.currentHealth -= 1;
                noneMenu.GetComponent<NoneMenu>().UpdateHearts();
            }

            timerObj.GetComponent<TextMeshProUGUI>().text = ((int) timer).ToString();
        }
    }

    public override void OpenMenu()
    {
        base.OpenMenu();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        timerRunning = true;
    }

    public override void CloseMenu()
    {
        base.CloseMenu();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        timer = 60f; timerRunning = false;
    }

    // Help from ChatGPT on learning how to get GameScreen to know when a button is clicked
    public void OnButtonClicked()
    {
        if (puzzleGrid.CheckForWinner())
        {
            uiMan.GoToMenu(GameMenu.None);
        }
    }
}