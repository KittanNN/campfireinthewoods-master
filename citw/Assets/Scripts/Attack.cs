using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    public LayerMask mask;
    public float reloadTime;
    public float damage;
    float currentReload;
    public Wood wood;
    public bool isChainsaw;
    public Animator a;
    public Animator a2;
    public Animator a3;
    public AnimationController ai;
    public PlayerMove3D pm3d;

    float tempForce;
    [HideInInspector] public Vector3[] Angles = new Vector3[8];

	// Use this for initialization
	void Awake () {

        Vector3 startVector = new Vector3(0, 0, -1);

        for (int i = 0; i < 8; i++)
        {
            Angles[i] = Quaternion.Euler(0, 45 * i, 0) * startVector;
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (MenuPause.isMenuOpen)
            return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time - currentReload >= reloadTime)
            {
               
                Collider[] list = Physics.OverlapBox(transform.position + transform.forward * 0.6f, new Vector3(.3f, .3f, .75f), transform.rotation, mask);

                Vector3 smallestAngleVec = Angles[0];
                float smallestAngle = Vector3.Angle(transform.forward, smallestAngleVec);

            
                for (int i = 0; i < 8; i++)
                {
                    Vector3 forward = transform.forward;
                    
                    float newAngle = Vector3.Angle(forward, Angles[i]);


                    if (newAngle < smallestAngle)
                    {
                        smallestAngleVec = Angles[i];
                        smallestAngle = newAngle;
                    }

                    
                }


                int AttackDir = 0;

                for (int i = 0; i < 8; i++)
                {
                    AttackDir = smallestAngleVec == Angles[i] ? i : AttackDir;
                }


                ai.isAttacking = true;
                
                a.SetInteger("Dir", AttackDir);
                a2.SetInteger("Dir", AttackDir);
                a3.SetInteger("Dir", AttackDir);
                a2.SetBool("isAttacking", true);
                a.SetBool("isAttacking", true);
                a3.SetBool("isAttacking", true);

                foreach (Collider item in list)
                {
                    switch (item.tag)
                    {
                        case "Enemy":
                            attackEnemy(item.GetComponent<BasicEnemy>());                            
                            break;
                        case "Trees":
                            attackTree(item.GetComponent<tree>());
                            break;
                    }

                   

                }
                StartCoroutine(StopPlayer());
                currentReload = Time.time;
                
                //tempForce = pm3d.force;
                //pm3d.force = 0;
            }
        }


    }

    void attackTree(tree treeComp)
    {
        

        if (treeComp.wood == null)
            treeComp.wood = this.wood;

        treeComp.dealDamage(damage, isChainsaw);
    }

    void attackEnemy(BasicEnemy enemy)
    {
        
        enemy.dealDamage(damage);
    }


    IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        ai.isAttacking = false;
        a.SetBool("isAttacking", false);
        a2.SetBool("isAttacking", false);
        a3.SetBool("isAttacking", false);
        //pm3d.force = tempForce;
    }
    



   /* void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 1, 1);
       
        Gizmos.DrawWireCube(transform.position + transform.forward * 0.5f, new Vector3(.5f, .5f, .5f));
    }
    */

}
