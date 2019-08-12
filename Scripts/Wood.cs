using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {

    public int maxWood;
    public int currentWood;


    public void addWood(int amount)
    {
        if (currentWood + amount <= maxWood)
            currentWood += amount;
        else
            currentWood = maxWood;
    }
}
