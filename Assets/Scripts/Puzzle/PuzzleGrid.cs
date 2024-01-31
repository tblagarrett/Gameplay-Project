using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGrid : MonoBehaviour
{
    private PuzzleSwitch[] puzzleSwitches;
    public delegate void ButtonClickHandler();
    public event ButtonClickHandler OnButtonClicked;
    private const int _gridSize = 9;
    private int _permutations = (int) (Mathf.Pow(2, _gridSize) - 2);

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

    // Number must be between 0 and 511
    public void GridFromInt(int num)
    {
        for (int i = 0; i < _gridSize; i++)
        {
            PuzzleSwitch puzzleSwitch = puzzleSwitches[i];
            // Got help on setting this up from ChatGPT: " I would like to write a loop that goes through the 9 least significant bits of an int and grabs them 1 by 1, how would I go about that?"
            PuzzleSwitchState bit = (PuzzleSwitchState) (((num >> i) & 1) ^ 1);
            puzzleSwitch.setSwitchState(bit);
        }
    }

    public void GenerateRandomGrid()
    {
        int gridState = Random.Range(0, _permutations);
        this.GridFromInt(gridState);
    }
}
