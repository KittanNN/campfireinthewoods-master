using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_armor : InteractiveObject
{

    public int newWarmth;


    public override void Enter(Collider other)
    {
        var temp = other.GetComponent<Warmth>();
        temp.maxWarmth = newWarmth;
        temp.changeWarmth(newWarmth);
        this.objectDestroy();
    }
}
