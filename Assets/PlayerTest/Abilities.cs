using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public Ability[] abilities = new Ability[4]; //abilities from assets
    Ability[] useAbilities = new Ability[4]; //abilities to use, so you can have multiple of one ability
    bool oneDown = false;
    bool twoDown = false;
    bool threeDown = false;
    bool fourDown = false;

    private void Start()
    {
        for (int i = 0; i < 4; i++) //create new instances of abilities so they're not all the same
        {
            useAbilities[i] = ScriptableObject.CreateInstance("Ability") as Ability; //https://answers.unity.com/questions/310847/how-to-create-instance-of-scriptableobject-and-pas.html
            useAbilities[i].Create(abilities[i]);
        }
    }

    void Update()
    {
        foreach (Ability a in useAbilities) //update time since use for all abilities
        {
            if (a != null)
            {
                a.timeSinceUse += Time.deltaTime;
            }
        }

        if (Input.GetAxis("ab1") > 0) //holding ability key
        {
            oneDown = true;
            useAbilities[0].Hold();
        }
        if (Input.GetAxis("ab2") > 0)
        {
            twoDown = true;
            useAbilities[1].Hold();
        }
        if (Input.GetAxis("ab3") > 0)
        {
            threeDown = true;
            useAbilities[2].Hold();
        }
        if (Input.GetAxis("ab4") > 0)
        {
            fourDown = true;
            useAbilities[3].Hold();
        }

        if (Input.GetAxis("ab1") == 0 && oneDown) //releasing ability key
        {
            oneDown = false;
            useAbilities[0].Use();
        }
        if (Input.GetAxis("ab2") == 0 && twoDown)
        {
            twoDown = false;
            useAbilities[1].Use();
        }
        if (Input.GetAxis("ab3") == 0 && threeDown)
        {
            threeDown = false;
            useAbilities[2].Use();
        }
        if (Input.GetAxis("ab4") == 0 && fourDown)
        {
            fourDown = false;
            useAbilities[3].Use();
        }
    }
}
