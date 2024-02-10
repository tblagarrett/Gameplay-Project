using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
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

    public override void CloseRoom()
    {
        base.CloseRoom();
    }

    public override void OpenRoom()
    {
        base.OpenRoom();
    }
}
