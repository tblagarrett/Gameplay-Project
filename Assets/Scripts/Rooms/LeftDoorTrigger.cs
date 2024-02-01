using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorTrigger : MonoBehaviour
{
    private RoomList target;
    private LevelManager levelManager;
    [SerializeField] private GameObject room;
    
    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        target = room.GetComponent<Room>().leftDoorDest;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Go to the target room
    private void OnTriggerEnter(Collider other)
    {
        target = room.GetComponent<Room>().leftDoorDest;

        Debug.Log("Left Door: " + target);
        Debug.Log("Right Door: " + room.GetComponent<Room>().rightDoorDest);

        levelManager.GoToRoom(target);
    }
}
