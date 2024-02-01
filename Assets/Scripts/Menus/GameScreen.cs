using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : Menu
{
    [HideInInspector] public PuzzleGrid puzzleGrid;
    UIManager uiMan;
    private void Start()
    {
        // Whenever a button is clicked, we run this function
        puzzleGrid = GetComponentInChildren<PuzzleGrid>();
        puzzleGrid.OnButtonClicked += OnButtonClicked;

        uiMan = UIManager.Instance;
    }

    public override void OpenMenu()
    {
        base.OpenMenu();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public override void CloseMenu()
    {
        base.CloseMenu();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Help from ChatGPT on learning how to get GameScreen to know when a button is clicked
    public void OnButtonClicked()
    {
        if (puzzleGrid.CheckForWinner())
        {
            puzzleGrid.Clear();
        }
    }
}