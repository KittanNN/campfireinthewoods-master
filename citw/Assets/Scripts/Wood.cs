using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wood : MonoBehaviour {

    public int maxWood;
    public int currentWood;
    public Text text;

    public void addWood(int amount)
    {
        if (currentWood + amount <= maxWood)
            currentWood += amount;
        else
            currentWood = maxWood;

        text.text = currentWood.ToString();
    }
}
