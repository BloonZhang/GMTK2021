using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElecDraggableController : MonoBehaviour
{
    [SerializeField] int mouseButton = 2; // 0 = left, 1 = right, 2 = middle

    // GameObjects
    [SerializeField] GameObject grid;

    // Definition
    // TODO: change based on zoom level
    Vector2 dragMaxLimit = new Vector3(7.8f, 3.9f);
    Vector2 dragMinLimit = new Vector3(1.9f, -2f);

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
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition = new Vector3(Mathf.Clamp(curPosition.x, dragMinLimit.x, dragMaxLimit.x),
                                      Mathf.Clamp(curPosition.y, dragMinLimit.y, dragMaxLimit.y),
                                      curPosition.z);
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
