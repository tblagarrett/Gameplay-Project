using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRoom : Room
{
    private UIManager uiManager;
    [SerializeField] GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void CloseRoom()
    {
        base.CloseRoom();
    }

    public override void OpenRoom()
    {
        base.OpenRoom();
        water.SetActive(true);
    }
}
