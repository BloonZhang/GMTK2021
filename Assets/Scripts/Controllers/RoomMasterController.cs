using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMasterController : MonoBehaviour
{

    //////// Singleton shenanigans ////////
    private static RoomMasterController _instance;
    public static RoomMasterController Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    [SerializeField]
    public List<RoomController> myList;
    public Dictionary<int, int> myDict;
    public int myInt;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
