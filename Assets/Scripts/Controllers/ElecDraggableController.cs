using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElecDraggableController : MonoBehaviour
{
    [SerializeField] int mouseButton = 2; // 0 = left, 1 = right, 2 = middle

    // GameObjects
    [SerializeField] GameObject grid;

    // helper
    bool isDragActive = false;
    bool isMouseOver = false;
    Vector3 offset = new Vector3();

    void Update()
    {
        // On click
        if (Input.GetMouseButtonDown(mouseButton) && isMouseOver)
        {
            isDragActive = true;
            offset = grid.transform.position - 
                        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 
                                                                   Input.mousePosition.y, 
                                                                   0));
                                                                   
        }

        // On release
        if (Input.GetMouseButtonUp(mouseButton))
        {
            isDragActive = false;
        }

        if (isDragActive)
        {
            Debug.Log("dragging");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            grid.transform.position = curPosition;
        }
    }

    public void OnMouseEnter()
    {
        isMouseOver = true;
    }
    public void OnMouseExit()
    {
        isMouseOver = false;
    }

}
