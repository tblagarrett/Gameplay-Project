using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoom : Room
{
    private UIManager uiManager;
    [SerializeField] private GameObject enemy;

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
        enemy.GetComponent<EnemyScript>().TPToSpawn();
        enemy.GetComponent<EnemyScript>().chasePlayer = false;
    }

    public override void OpenRoom()
    {
        enemy.SetActive(true);
        enemy.GetComponent<EnemyScript>().TPToSpawn();
        base.OpenRoom();
        enemy.GetComponent<EnemyScript>().chasePlayer = true;
    }
}
