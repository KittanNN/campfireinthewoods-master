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


	// Use this for initialization
	void Start () {
        w = player.GetComponent<Warmth>();
        pl = transform.GetChild(0).GetComponent<Light>();
        maxLightRange = pl.range;
        hp = maxVisibleWood * transferRate;
	}

	
	// Update is called once per frame
	void FixedUpdate () {
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
                    wood.currentWood = 0;
                }
            }

        }
        
        hp -= ((hp - decreaseRate) >= 0) ? decreaseRate : 0;
        pl.range = ((hp / transferRate) > maxLightRange) ? maxLightRange : hp / transferRate;


    }

    void addWood(int woodAmount)
    {
        hp += transferRate * woodAmount;
    }
}
