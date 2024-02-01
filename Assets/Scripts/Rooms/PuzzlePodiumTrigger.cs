using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePodiumTrigger : MonoBehaviour
{
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Go to the target room
    private void OnTriggerEnter(Collider other)
    {
        uiManager = UIManager.Instance;
        uiManager.GoToMenu(GameMenu.Game);
    }
}
