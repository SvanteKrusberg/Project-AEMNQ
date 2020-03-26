using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    bool oneDown = false;
    bool twoDown = false;
    bool threeDown = false;
    bool fourDown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("ab1") > 0)
        {
            oneDown = true;
        }
        if (Input.GetAxis("ab2") > 0)
        {
            twoDown = true;
        }
        if (Input.GetAxis("ab3") > 0)
        {
            threeDown = true;
        }
        if (Input.GetAxis("ab4") > 0)
        {
            fourDown = true;
        }

        if (Input.GetAxis("ab1") == 0 && oneDown)
        {
            oneDown = false;
            print("use ab1");
        }
        if (Input.GetAxis("ab2") == 0 && twoDown)
        {
            twoDown = false;
            print("use ab2");
        }
        if (Input.GetAxis("ab3") == 0 && threeDown)
        {
            threeDown = false;
            print("use ab3");
        }
        if (Input.GetAxis("ab4") == 0 && fourDown)
        {
            fourDown = false;
            print("use ab4");
        }
    }
}
