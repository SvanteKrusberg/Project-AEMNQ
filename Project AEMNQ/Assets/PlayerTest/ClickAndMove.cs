using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndMove : MonoBehaviour
{
    public Transform target;
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
                target.position = hit.point; //move taget to clicked position
            }
            else print("bruh"); //if raycast didn't hit anything within the walkMask
        }
    }

}
