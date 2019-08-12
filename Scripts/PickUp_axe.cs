using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_axe : InteractiveObject
{

    public int newDamage;


    public override void Enter(Collider other)
    {
        other.transform.GetChild(6).GetComponent<Attack>().damage = newDamage;
        this.objectDestroy();
    }
}
