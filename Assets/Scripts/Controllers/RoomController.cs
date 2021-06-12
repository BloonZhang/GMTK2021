using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: this class does not need to be monovehaviour
public class RoomController : MonoBehaviour
{
    public string name = "DefaultName";
    public string id = "DefaultID";

    private Dictionary<string, bool> flags = new Dictionary<string, bool>();

    public void ChangeName(string str) { this.name = str; }
    public void ChangeID(string str) { this.id = str; }

    public void AddFlag(string flagName)
    {
        if (!flags.ContainsKey(flagName)) { flags.Add(flagName, false); }
    }
    public void SetFlag(string flagName, bool state) 
    {
        if (!flags.ContainsKey(flagName)) { flags.Add(flagName, state); }
        else { flags[flagName] = state; }
    }
    public bool GetFlag(string flagName)
    {
        if (flags.ContainsKey(flagName)) { return flags[flagName]; }
        else 
        {
            Debug.Log("Tried to get nonexistent flag \"" + flagName + "\" from room \"" + this.name);
            return false;
        }
    }
}
