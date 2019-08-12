using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfire : MonoBehaviour {

    public Transform player;
    public float decreaseRate;
    public float warmthDecreaseRate;
    public int maxVisibleWood;
    public float warmthGiveMultiplier;
    public bool isClose;

    public Wood wood;

    public float hp;
    float transferRate = 22.5f;
    Warmth w;
    Light pl;
    float maxLightRange;
    bool hasDied;
    bool hasAlerted;
    bool hasAlertedLowHP;

	// Use this for initialization
	void Start () {
        w = player.GetComponent<Warmth>();
        pl = transform.GetChild(0).GetComponent<Light>();
        maxLightRange = pl.range;
        hp = maxVisibleWood * transferRate;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
        if (MenuPause.isMenuOpen)
            return;


        if (Vector3.Distance(player.position, transform.position) > 3 || pl.range < 0.1f)
        {
            w.changeWarmth(-warmthDecreaseRate);
            isClose = false;
        }
        else
        {
            isClose = true;
            w.changeWarmth((warmthDecreaseRate * warmthGiveMultiplier) * (pl.range / maxLightRange));

            if (Vector3.Distance(player.position, transform.position) < 1.3f )
            {

                if (wood.currentWood > 0)
                {
                    addWood(wood.currentWood);
                    GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("-" + wood.currentWood + " Wood");
                    wood.addWood(-wood.currentWood);
                    
                }
            }

        }
        
        hp -= hp > 0 ? decreaseRate : 0;
        pl.range = ((hp / transferRate) > maxLightRange) ? maxLightRange : hp / transferRate;

        hasDied = hp <= 0 ? true : false;


        if (!hasDied && !hasAlertedLowHP && hp < 50)
        {
            GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("Campfire is dying", Vector3.zero + Camera.main.transform.up * .2f, 3.0f);
            GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("Collect more wood and feed the fire", 3.0f);
            hasAlertedLowHP = true;
        }

        if (hp > 50)
            hasAlertedLowHP = false;

        if (hasDied && !hasAlerted)
        {
            GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert("Campfire has died", 2.0f);
            hasAlerted = true;
        }
    }

    void addWood(int woodAmount)
    {
        hp += transferRate * woodAmount;
    }
}
