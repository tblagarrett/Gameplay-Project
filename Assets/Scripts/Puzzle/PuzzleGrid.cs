using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGrid : MonoBehaviour
{
    private PuzzleSwitch[] puzzleSwitches;
    public delegate void ButtonClickHandler();
    public event ButtonClickHandler OnButtonClicked;

    // Start is called before the first frame update
    void Start()
    {
        // instatiate array of switches
        puzzleSwitches = GetComponentsInChildren<PuzzleSwitch>(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        // Get all PuzzleSwitch components from children buttons
        PuzzleSwitch[] puzzleSwitches = GetComponentsInChildren<PuzzleSwitch>();

        // Subscribe to the event for each PuzzleSwitch
        foreach (PuzzleSwitch puzzleSwitch in puzzleSwitches)
        {
            puzzleSwitch.ButtonClick += ButtonClicked;
        }
    }

    public bool CheckForWinner()
    {
        foreach (PuzzleSwitch sw in puzzleSwitches)
        {
            if (sw.state == PuzzleSwitchState.off)
            {
                return false;
            }
        }

        return true;
    }

    public void Freeze()
    {
        foreach (PuzzleSwitch puzzleSwitch in puzzleSwitches)
        {
            puzzleSwitch.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void Unfreeze()
    {
        foreach (PuzzleSwitch puzzleSwitch in puzzleSwitches)
        {
            puzzleSwitch.gameObject.GetComponent<Button>().enabled = true;
        }
    }

    public void ButtonClicked()
    {
        if (OnButtonClicked != null) { OnButtonClicked(); }
    }

    public void Clear()
    {
        foreach (PuzzleSwitch puzzleSwitch in puzzleSwitches)
        {
            puzzleSwitch.setSwitchState(PuzzleSwitchState.off);
        }
    }
}
