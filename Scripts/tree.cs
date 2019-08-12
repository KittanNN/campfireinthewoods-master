using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {

    public int health;
    public int woodAmount;

    public Wood wood;


    public void dealDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            wood.addWood(woodAmount);
            Destroy(this.gameObject);
        }

    }
}
