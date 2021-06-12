using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WireMasterController : MonoBehaviour
{
    //////// Singleton shenanigans ////////
    private static WireMasterController _instance;
    public static WireMasterController Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    [SerializeField] GameObject gridObject;




    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

}
