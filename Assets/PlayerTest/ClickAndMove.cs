using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndMove : MonoBehaviour
{
    public MoveToTarget playerMover;
    public Interactable focus;
    public Transform cursor;
    public Camera cam;
    public LayerMask walkMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) //if right clicked
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 500, walkMask)) //Send raycast from mouse to ground
            {
                cursor.position = hit.point; //move taget to clicked position
                RemoveFocus();
            }
            else print("bruh"); //if raycast didn't hit anything within the walkMask
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 500))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }

            playerMover.FollowTarget(newFocus);
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        playerMover.StopFollowingTarget();
    }
}
