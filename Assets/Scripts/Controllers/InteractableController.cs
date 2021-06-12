using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : ClickableArea
{
    [SerializeField] string observationText;

    protected override void OnMouseOver()
    {
        if (!ClickableArea.lockClicks)
        {
            // Debug.Log("mouse is over: " + this.name);
        }
    }

    // TODO: add locks/flags
    protected override void OnMouseUpAsButton()
    {
        if (!ClickableArea.lockClicks)
        {
            // Debug.Log("clicked on: " + this.name);
            DialogueController.Instance.SetDialogue(observationText);
        }
    }

}
