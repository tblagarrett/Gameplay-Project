using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Transform spawn;
    public RoomList leftDoorDest;
    public RoomList rightDoorDest;
    private LevelManager levelManager;
    private PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        playerManager = PlayerManager.Instance;

        RoomList[] rooms = levelManager.GetShuffledRooms();
        leftDoorDest = rooms[0];
        rightDoorDest = rooms[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void CloseRoom()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void OpenRoom()
    {
        this.gameObject.SetActive(true);
        levelManager = LevelManager.Instance;
        playerManager = PlayerManager.Instance;

        // set the destinations of the doors
        RoomList[] rooms = levelManager.GetShuffledRooms();
        leftDoorDest = rooms[0];
        rightDoorDest = rooms[1];

        string list = "[";
        for (int i = 0; i < rooms.Length; i++)
        {
            list += rooms[i].ToString() + ", ";
        }
        list += "]";
        Debug.Log(list);

        // Only spawn the healing room if the player has lost health
        if (playerManager.currentHealth >= playerManager.maxHealth)
        {
            if (leftDoorDest == RoomList.Healing)
            {
                leftDoorDest = rooms[2];
            }
            if (rightDoorDest == RoomList.Healing)
            {
                rightDoorDest = rooms[2];
            }
        }

        // TP the player to spawn
        playerManager.Player.GetComponent<PlayerMovement>().TeleportToSpawn();
    }

    public Vector3 GetSpawnLocation()
    {
        return this.spawn.transform.position;
    }
}
