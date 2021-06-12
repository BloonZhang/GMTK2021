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


    ElectricalComponent.Component[,] elecGrid = new ElectricalComponent.Component[18, 18];

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}
    }

    // public methods
    public void SetCell(int x, int y, ElectricalComponent.Component component)
    {
        elecGrid[x,y] = component;
    }
    public void EmptyCell(int x, int y)
    {
        elecGrid[x,y] = ElectricalComponent.Component.empty;
    }

}
