using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : InteractiveObject
{
    public float timer;
    [HideInInspector] public float start;
    float oldForce;

    PlayerMove3D pm3d;

    void FixedUpdate()
    {
        if (start != 0)
            if (Time.time - start >= timer)
            {
                this.objectDestroy();
                pm3d.force = oldForce; 
            }


    }

    public override void Enter(Collider other)
    {
        pm3d = other.GetComponent<PlayerMove3D>();
        oldForce = pm3d.force;
        
        timer *= 200 / oldForce;
        start = Time.time;
        pm3d.force = 0;
    }
}
