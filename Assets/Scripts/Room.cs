using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform spawn;
    public GameObject leftDoorDest;
    public GameObject rightDoorDest;
    private LevelManager levelManager;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        playerManager = PlayerManager.Instance;

        leftDoorDest = levelManager.GetRandomRoom();
        rightDoorDest = levelManager.GetRandomRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseRoom()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenRoom()
    {
        this.gameObject.SetActive(true);
        
        // set the destinations of the doors
        leftDoorDest = levelManager.GetRandomRoom();
        rightDoorDest = levelManager.GetRandomRoom();

        // TP the player to spawn
        playerManager.Player.GetComponent<PlayerMovement>().TeleportToSpawn();
    }

    public Vector3 GetSpawnLocation()
    {
        return this.spawn.transform.position;
    }
}
