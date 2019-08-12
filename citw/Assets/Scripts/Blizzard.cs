using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour {

    float start;
    float offset;
    public Warmth w;
    public campfire c;

	// Use this for initialization
	void Start ()
    {
        startTimer( Random.Range(4f, 7f));
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (start != 0)
        {
            if (Time.time - start >= 0)
            {
                startBlizzard();
            }
        }       
		
	}

    void startTimer(float timeOffset)
    {
        start = Time.time + timeOffset;
        offset = timeOffset;
    }

    void startBlizzard()
    {
        if (c.isClose == false)
        {
            w.changeWarmth(-c.warmthDecreaseRate * 3);
        }
        print(offset.ToString());
        start = 0;
        startTimer(Random.Range(30f, 45f));
    }
}
