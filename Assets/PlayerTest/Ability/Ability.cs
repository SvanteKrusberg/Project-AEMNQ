using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class Ability : ScriptableObject
{
    public float range; //how far the ability goes
    public float dmg; //how much damage it deals
    public int requirement; //how much ?mana? it uses
    public new string name;
    public bool skillShot;
    public float coolDown;
    public float timeSinceUse;

    public void Use() //use the ability
    {
        if (coolDown <= timeSinceUse)
        {
            Debug.Log("Use " + name);
            timeSinceUse = 0;
        }
    }

    public void Hold() //show direction and range when holding down the key to use the ability
    {
        timeSinceUse += Time.deltaTime;
        if (coolDown <= timeSinceUse)
        {
            //Debug.Log("Hold " + name);
        }
    }

    public void Create(Ability a)
    {
        range = a.range;
        dmg = a.dmg;
        requirement = a.requirement;
        name = a.name;
        skillShot = a.skillShot;
        coolDown = a.coolDown;
        timeSinceUse = coolDown;
    }
}
