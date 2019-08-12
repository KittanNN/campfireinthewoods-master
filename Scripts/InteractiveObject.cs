using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Enter(other);
    }

    public abstract void Enter(Collider other);

    public virtual void objectDestroy()
    {
        Destroy(this.gameObject);
    }
    

}
