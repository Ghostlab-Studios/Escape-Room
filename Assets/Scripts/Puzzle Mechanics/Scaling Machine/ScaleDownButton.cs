using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleDownButton : Interactable
{
    public Platform platform;

    [SerializeField]
    private float inputDelay = 0.1f; //change this value to whatever time the action occuring necessitates

    [SerializeField]
    private float timer = 0; //leave this value alone, this is just to start counting at 0

    private void Update() //important to update time here, not in Interact. Interact only runs when player is actively interacting with object
    {
        timer += Time.deltaTime;
    }

    protected override void Interact()
    {
        if (timer >= inputDelay)
        {
            //perform whatever actions here
            Scalable scalableObject = platform.GetCurrentScalableObject();
            if (scalableObject != null)
            {
                scalableObject.ScaleDown();
            }
            timer = 0; //reset timer for input delay
        }
    }
}
