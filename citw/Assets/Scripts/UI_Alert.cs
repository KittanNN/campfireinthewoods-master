using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Alert : MonoBehaviour {

    RectTransform t;
    Text s;

    public float DestroyTime;
    float start;
    float alphaStart = 255;
    public float speed;

	// Use this for initialization
	void Start () {
        start = Time.time;
        t = GetComponent<RectTransform>();
        s = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        t.position += t.up  * (.03f / speed);
        float temp = ((alphaStart - 4 / speed) < 0 ? 0 : alphaStart -= 4 / speed) ;
        s.color = new Color32(255,255,255, (byte)temp);

        if (Time.time - start > DestroyTime * speed)
        {
            Destroy(transform.parent.gameObject);
        }
	}
}
