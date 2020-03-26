using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public float speed = 0.01f;
    public Transform cursor;
    public Transform focus; // interactable object in focus

    // Update is called once per frame
    void Update()
    {
        //float distance = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.position.x, target.position.z))); //distance between player and target
        //if (distance > .1f) //so it wont move when standing still
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), .01f); //move player towards target, ignors y to avoid stutter
        //}

        if (focus == null)
        {
            MoveToPoint(cursor.position);
        }
        else
        {
           // MoveToPoint(focus.position);

            if (GetDistance(new Vector2(focus.position.x, focus.position.z), new Vector2(transform.position.x, transform.position.z)) > 1)
            {
                //Debug.Log("distance = " + GetDistance(new Vector2(focus.position.x, focus.position.z), new Vector2(transform.position.x, transform.position.z)));
                MoveToPoint(focus.position);
            }
            else
            {
                StopFollowingTarget();
                cursor.position = transform.position;
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        //float distance = Mathf.Abs(Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(point.x, point.z))); //distance between player and target
        if (GetDistance(new Vector2(transform.position.x, transform.position.z), new Vector2(point.x, point.z)) > .1f) //so it wont move when standing still
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(point.x, transform.position.y, point.z), speed); //move player towards target, ignors y to avoid stutter
        }
    }

    public void FollowTarget(Interactable newTarget)
    {
        focus = newTarget.transform;
    }

    public void StopFollowingTarget()
    {
        focus = null;
    }

    float GetDistance(Vector2 vOne, Vector2 vTwo)
    {
        float distance = Mathf.Abs(Vector2.Distance(vOne, vTwo));
        return distance;
    }
}
