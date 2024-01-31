using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PuzzleSwitchState { on, off };

public class PuzzleSwitch : MonoBehaviour
{
    private PuzzleSwitchState _state;
    public PuzzleSwitchState startingState;
    [SerializeField] private Sprite offSprite;
    [SerializeField] private Sprite onSprite;

    public delegate void ButtonClickHandler();
    public event ButtonClickHandler ButtonClick;

    // References to Neighbors
    private PuzzleSwitch[] puzzleSwitches;
    [SerializeField] private PuzzleSwitch up;
    [SerializeField] private PuzzleSwitch down;
    [SerializeField] private PuzzleSwitch left;
    [SerializeField] private PuzzleSwitch right;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the array with size 4 since there are four neighbors
        puzzleSwitches = new PuzzleSwitch[4];

        // Assign neighbors to the array
        puzzleSwitches[(int)Direction.Up] = up;
        puzzleSwitches[(int)Direction.Down] = down;
        puzzleSwitches[(int)Direction.Left] = left;
        puzzleSwitches[(int)Direction.Right] = right;

        // Initialize switch state and image
        _state = startingState;
        if (_state == PuzzleSwitchState.on)
        {
            this.GetComponent<Image>().sprite = onSprite;
        } else
        {
            this.GetComponent<Image>().sprite = offSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapSwitchState()
    {
        if (_state == PuzzleSwitchState.on)
        {
            // Turn off
            _state = PuzzleSwitchState.off;
            this.GetComponent<Image>().sprite = offSprite;
        } else
        {
            // Turn on
            _state = PuzzleSwitchState.on;
            this.GetComponent<Image>().sprite = onSprite;
        }
    }

    // Swap this switch and the neighbors
    public void makeMove()
    {
        this.swapSwitchState();

        // swap neighbors, if they exist
        foreach (PuzzleSwitch puzzleSwitch in puzzleSwitches)
        {
            if (puzzleSwitch != null)
            {
                puzzleSwitch.swapSwitchState();
            }
        }

        // Tell the parent class that a move was made
        if (ButtonClick != null) { ButtonClick(); }
    }

    public void setSwitchState(PuzzleSwitchState state)
    {
        _state = state;
        if (_state == PuzzleSwitchState.on)
        {
            this.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            this.GetComponent<Image>().sprite = offSprite;
        }
    }

    public PuzzleSwitchState state { get { return _state; } }

    // Enum to represent directions
    private enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
