using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{

    //////// Singleton shenanigans ////////
    private static DialogueController _instance;
    public static DialogueController Instance { get {return _instance;} }
    //////// Singleton shenanigans continue in Awake() ////

    [SerializeField] GameObject textArea;
    [SerializeField] TextMeshProUGUI myTMP;

    GraphicRaycaster raycaster;

    void Awake()
    {
        // Singleton shenanigans
        if (_instance != null && _instance != this) {Destroy(this.gameObject);} // no duplicates
        else {_instance = this;}

        this.raycaster = GetComponent<GraphicRaycaster>();
        //ClickableArea.lockClicks = true; // optional
    }

    // Update is called once per frame
    void Update()
    {   
        // If LMB is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // set up PointerEvent
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            // Raycast
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
                if (result.gameObject == textArea) { CloseDialogue(); }
                // alternatively
                // if (result.gameObject == this) { CloseDialogue(); }
            }
        }
    }

    // Helper methods
    public void SetText(string str)
    {
        myTMP.text = str;
    }
    void OpenDialogue()
    {
        textArea.SetActive(true);
    }
    void OpenDialogue(string str)
    {
        SetText(str);
        OpenDialogue();
    }
    void CloseDialogue()
    {
        SetText("");
        // ClickableArea.lockClicks = false; // optional
        textArea.SetActive(false);
    }
}
