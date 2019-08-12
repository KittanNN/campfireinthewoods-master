using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_chainsaw : InteractiveObject
{
    public float newDamage;
    public float newReloadTime;


    public override void Enter(Collider other)
    {
        other.transform.GetChild(8).GetComponent<Attack>().damage = newDamage;
        other.transform.GetChild(8).GetComponent<Attack>().reloadTime = newReloadTime;
        other.transform.GetChild(8).GetComponent<Attack>().isChainsaw = true;
        other.transform.GetComponent<playerStats>().hasChainsaw = true;
        this.objectDestroy();
    }
}
