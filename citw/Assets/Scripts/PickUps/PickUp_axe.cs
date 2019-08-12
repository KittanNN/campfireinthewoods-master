using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_axe : InteractiveObject
{

    public int newDamage;


    public override void Enter(Collider other)
    {
        other.transform.Find("Fov").GetComponent<Attack>().damage = newDamage;
        GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("Axe upgrade", Vector3.zero + Camera.main.transform.up * .2f, 3.0f);
        GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("Old damage = 1 | New damage = 2", Vector3.zero, 3.0f);
        this.objectDestroy();
    }
}
