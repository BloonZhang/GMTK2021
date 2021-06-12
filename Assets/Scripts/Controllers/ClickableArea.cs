using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableArea : MonoBehaviour
{
    public static bool lockClicks = false;

    protected abstract void OnMouseOver();
    protected abstract void OnMouseUpAsButton();

}
