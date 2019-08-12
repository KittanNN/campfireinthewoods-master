using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warmth : MonoBehaviour {

    public InGameMenu igm;
    public Image img;
    public Image img2;
    public float maxWarmth;
    public PlayerMove3D pm;
    float warmth;
    float ogForce;
    float ogWarmth;
	// Use this for initialization
	void Start () {
        MenuPause.isDead = MenuPause.isMenuOpen = false;
        ogWarmth = warmth = maxWarmth;
        
        ogForce = pm.force;

	}

    public void changeWarmth(float amount)
    {
        if (warmth >= 0 && warmth + amount <= maxWarmth)
            warmth += amount;
    }

    
	
	// Update is called once per frame
	void Update () {
        print(MenuPause.isDead);
        if (MenuPause.isMenuOpen)
            return;

        img.fillAmount = warmth / maxWarmth;

        img2.fillAmount = ((warmth > 33.3f) ? 33.3f : warmth) / maxWarmth;

        if (warmth <= 33.3f)
        {
            float temp = ogForce / (33.3f / warmth);
            pm.force = (temp > 3) ? temp : 0;
        }

        if (warmth <= 0)
        {
            if (!MenuPause.isDead)
            {
                MenuPause.isDead = MenuPause.isMenuOpen = true;
                igm.openDeathMenu();
            }

        }
	}
}
