using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour {

    Transform player;
    NavMeshAgent nav;
    public float speed;
    public float health;
    public float minDamage;

    Rigidbody rb;
    EventCreator ec;
    float startHealth;
    HPBar bar;
    bool hasHealthbar;

    bool wasPaused;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        startHealth = health;
	}
	
	// Update is called once per frame
	void Update () {

        if (MenuPause.isMenuOpen)
        {
            nav.isStopped = MenuPause.isMenuOpen;
            wasPaused = true;
            return;
        }

        if (wasPaused)
            nav.isStopped = wasPaused = false;


        if (Vector3.Distance(player.position, transform.position) < 5)
        {
            nav.SetDestination(player.position);
        }
    }

    public virtual void dealDamage(float amount)
    {
        health -= amount;


        if (health < startHealth)
        {
            if (!hasHealthbar)
            {

                ec = GameObject.FindWithTag("DamageCanvas").GetComponent<EventCreator>();

                bar = ec.createHPBar(transform, new Vector3(0,0,0));

                hasHealthbar = true;
                
            }

        }

        bar.updateImage(health, startHealth);
        if (health <= 0)
        {
            ec.DestroyHpBar(bar);
            Destroy(this.gameObject);
        }
    }

}
