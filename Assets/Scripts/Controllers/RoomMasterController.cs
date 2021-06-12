using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMasterController : MonoBehaviour
{

    //////// Singleton shenanigans ////////
    private static RoomMasterController _instance;
    public static RoomMasterController Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    public List<RoomController> allRooms;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    public void SwitchToRoom(string id)
    {
        bool debug_changedRoom = false;
        ClickableArea.lockClicks = true;
        foreach (RoomController room in allRooms)
        {
            //room.enabled = (room.id != id);
            room.gameObject.SetActive(room.id == id);
            if (room.id == id) { debug_changedRoom = true; }
        }
        ClickableArea.lockClicks = false;
        if (!debug_changedRoom) { Debug.Log("SwitchToRoom(" + id + ") did not find any rooms."); }
    }


}
