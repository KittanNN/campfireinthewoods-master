using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warmth : MonoBehaviour {

    public Image img;
    public Image img2;
    public float maxWarmth;
    public PlayerMove3D pm;
    float warmth;
    float ogForce;
    float ogWarmth;
	// Use this for initialization
	void Start () {

        ogWarmth = warmth = maxWarmth;
        
        ogForce = pm.force;

	}

    public void changeWarmth(float amount)
    {
        if (warmth + amount > 0 && warmth + amount <= maxWarmth)
            warmth += amount;
    }

    
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = warmth / maxWarmth;

        img2.fillAmount = ((warmth > 33.3f) ? 33.3f : warmth) / maxWarmth;

        if (warmth <= 33.3f)
        {
            
            pm.force = ogForce / (33.3f / warmth);
        }
	}
}
