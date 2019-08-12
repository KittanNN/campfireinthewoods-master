using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public LayerMask mask;
    public float reloadTime;
    public int damage;
    float currentReload;
    //Collider2D coll;
    public Wood wood;
    

	// Use this for initialization
	void Start () {
        //coll = GetComponent<Collider2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time - currentReload >= reloadTime)
            {
               
                Collider[] list = Physics.OverlapBox(transform.position + transform.forward * 0.5f, new Vector3(.5f, .5f, .75f), transform.rotation, mask);




                foreach (Collider item in list)
                {
                    tree t = item.GetComponent<tree>();

                    if (t.wood == null)
                        t.wood = this.wood;

                    t.dealDamage(damage);
                }

                currentReload = Time.time;
            }
        }

        
	}

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 1, 1);
       
        Gizmos.DrawWireCube(transform.position + transform.forward * 0.5f, new Vector3(.5f, .5f, .5f));
    }


}
