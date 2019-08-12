using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree : MonoBehaviour {

    public EventCreator ec;
    public Vector3 offset;
    public float minDmg;
    public float health;
    public int woodAmount;

    HPBar bar;
    public GameObject canvas;


    float startHealth;
    [HideInInspector] public Wood wood;
    bool hasHealthbar;

    void Start()
    {
        startHealth = health;
        
    }

    public virtual void dealDamage(float amount, bool isChainsaw)
    {

        if (amount >= minDmg || isChainsaw)
        {
            health -= amount;
            if (bar != null )
            {
                bar.updateImage(health, startHealth);
            }
            if (health <= 0)
            {
                wood.addWood(woodAmount);
                Invoke("DestroyThis", 0.15f);
                
            }
        }

    }

    void DestroyThis()
    {
        int addWood = wood.currentWood == wood.maxWood ? 0 : woodAmount;
        string alertText = addWood == 0 ? "Inventory full" : "+" + addWood + " Wood";
        GameObject.FindWithTag("Event").GetComponent<EventCreator>().createAlert(alertText);
        ec.DestroyHpBar(bar);
        Destroy(this.gameObject);
    }

    void Update()
    {
        
        if (health < startHealth)
        {
            if (!hasHealthbar)
            {
                //print(healthBarObject == null);
                //canvas = GameObject.FindWithTag("Canvas");
                ec = GameObject.FindWithTag("DamageCanvas").GetComponent<EventCreator>();

                bar = ec.createHPBar(transform, new Vector3(0,1f,-.5f));

                //GameObject hb = Instantiate(healthBarObject, canvas.transform) as GameObject;
                //rt = hb.GetComponent<RectTransform>();
                //img = rt.GetComponent<Image>();
                hasHealthbar = true;
                bar.updateImage(health, startHealth);
            }
            //rt.position = new Vector3(transform.position.x , transform.position.y + 1f, transform.position.z + -.5f);
            //img.fillAmount = health / startHealth;
        }
    }
}
