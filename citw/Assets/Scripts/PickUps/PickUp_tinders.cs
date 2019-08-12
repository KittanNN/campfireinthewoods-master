using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_tinders : InteractiveObject
{

    public override void Enter(Collider other)
    {
        other.transform.GetComponent<playerStats>().hasTinders = true;
        Destroy(this.gameObject);
    }

}
