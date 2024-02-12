using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public enum RoomList
{
    Empty,
    Puzzle,
    Healing,
    Enemy
}

public class LevelManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] Rooms;
    public RoomList startingRoom;
    public RoomList currentRoom;

    private static LevelManager _instance; // make a static private variable of the component data type
    public static LevelManager Instance { get { return _instance; } } // make a public way to access the private variable\

    private void Awake()
    {
        if (_instance != null && _instance != this)
        { // if there is already a value assigned to the private variable and its not this, destroy this
            Destroy(this.gameObject);
        }
        else
        { // if there is no value assigned to the private variable, assign this as the reference
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject room in Rooms)
        {
            if (room.GetComponent<Room>() == null)
            {
                Debug.LogError("No Room found on " + room.name);
                continue;
            }
            room.GetComponent<Room>().CloseRoom();
            room.GetComponent<Transform>().position = Vector3.zero;
        }
        OpenRoom(startingRoom); //open a starting room if one is declared
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CloseRoom(RoomList Room)
    {
        Rooms[(int)Room].GetComponent<Room>().CloseRoom();

        return true;
    }

    private bool OpenRoom(RoomList Room)
    {
        Rooms[(int)Room].GetComponent<Room>().OpenRoom();
        currentRoom = Room;

        return true;
    }

    public void GoToRoom(RoomList Room)
    {
        CloseRoom(currentRoom);
        currentRoom = Room;
        OpenRoom(currentRoom);
    }

    public GameObject CurrentRoom()
    {
        return this.Rooms[(int)currentRoom];
    }

    public RoomList GetRandomRoom()
    {
        return (RoomList)UnityEngine.Random.Range(0, Rooms.Length);
    }

    public RoomList[] GetShuffledRooms()
    {
        RoomList[] tempRooms = (RoomList[])Enum.GetValues(typeof(RoomList));

        //https://forum.unity.com/threads/randomize-array-in-c.86871/ To shuffle the array
        for (int t = 0; t < tempRooms.Length; t++)
        {
            RoomList tmp = tempRooms[t];
            int r = UnityEngine.Random.Range(t, tempRooms.Length);
            tempRooms[t] = tempRooms[r];
            tempRooms[r] = tmp;
        }

        return tempRooms;
    }
}
