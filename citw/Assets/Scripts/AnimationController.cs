using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    Rigidbody r;
    Animator a;
    public Animator a2;
    public Animator a3;
    public bool isAttacking;
    int y = 0;
    int x = 0;
    [HideInInspector] public int direction;
    // Use this for initialization
    void Awake () {
        a = GetComponent<Animator>();
        r = transform.parent.GetComponent<Rigidbody>();


        y = 0;
        x = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //a.SetInteger("Dir", 0);
        if (MenuPause.isMenuOpen)
            return;



        Vector3 dir = Vector3.zero;

        y += Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        y += Input.GetKeyUp(KeyCode.W) ? -1 : 0;

        y += Input.GetKeyDown(KeyCode.S) ? -1 : 0;
        y += Input.GetKeyUp(KeyCode.S) ? 1 : 0;


        x += Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        x += Input.GetKeyUp(KeyCode.D) ? -1 : 0;


        x += Input.GetKeyDown(KeyCode.A) ? -1 : 0;
        x += Input.GetKeyUp(KeyCode.A) ? 1 : 0;

        if (isAttacking)
        {
            return;
        }


        if (x == 1 && y == -1)
        {
            a.SetInteger("Dir", 7);
        }
        else if (x == 1 && y == 1)
        {
            a.SetInteger("Dir", 5);
        }
        else if (x == -1 && y == 1)
        {
            a.SetInteger("Dir", 3);
        }
        else if (x == -1 && y == -1)
        {
            a.SetInteger("Dir", 1);
        }



        else if (x == 1 && y == 0)
        {
            a.SetInteger("Dir", 6);
        }
        else if (x == 0 && y == 1)
        {
            a.SetInteger("Dir", 4);
        }
        else if (x == -1 && y == 0)
        {
            a.SetInteger("Dir", 2);
        }
        else if (x == 0 && y == -1)
        {
            a.SetInteger("Dir", 0);
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

        }
        else
        {
            a.SetInteger("Dir", 8);
        }

        a2.SetInteger("Dir", a.GetInteger("Dir"));
        a3.SetInteger("Dir", a.GetInteger("Dir"));
    }

    public bool GetAxis()
    {
        return (y != 0 && x != 0);
    }

    bool isEqual(Vector3 current, Vector3 check)
    {

        bool lmao = true;

        for (int i = 0; i < 3; i++)
        {
            print(current[i] + ":" + check[i]);
            //lmao = current[i] == check[i] ? lmao : false;
        }


        return lmao;
    }


    bool checkVec(Vector3 first, Vector3 second)
    {
        return first == Vector3.Max(first, second);
    }
}
