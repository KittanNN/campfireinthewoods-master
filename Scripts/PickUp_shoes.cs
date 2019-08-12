using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_shoes : InteractiveObject
{

    public int newForce;


    public override void Enter(Collider other)
    {
        other.GetComponent<PlayerMove3D>().force = newForce;
        this.objectDestroy();
    }
}
