using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        float distance = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.position.x, target.position.z))); //distance between player and target
        if (distance > .1f) //so it wont move when standing still
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), .01f); //move player towards target, ignors y to avoid stutter
        }
    }
}
