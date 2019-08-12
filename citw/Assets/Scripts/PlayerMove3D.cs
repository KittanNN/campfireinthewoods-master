using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour {

    bool isMoving;
    bool isRunning;
    Rigidbody r;
    public float force;
    [HideInInspector] public float ogForce;
    public float stamina;
    public float staminaDecreaseRate;
    public float staminaCooldownRate;
    float runMultiplier;
    Animator a;
    Animator a2;
    Animator a3;
    public AnimationController AC;

    // Use this for initialization
    void Awake () {
        r = GetComponent<Rigidbody>();
        ogForce = force;
        a = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        a2 = transform.GetChild(0).GetChild(1).GetComponent<Animator>();
        a3 = transform.GetChild(0).GetChild(2).GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (MenuPause.isMenuOpen)
            return;

        if (AC.isAttacking)
        {
            return;
        }

        if (AC.GetAxis())
            runMultiplier *= .75f;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.A))
                r.AddForce(new Vector3(-force * runMultiplier, 0,0), ForceMode.Force);

            if (Input.GetKey(KeyCode.D))
                r.AddForce(new Vector3(force * runMultiplier, 0,0 ), ForceMode.Force);

            if (Input.GetKey(KeyCode.W))
                r.AddForce(new Vector3(0,0, force * runMultiplier), ForceMode.Force);

            if (Input.GetKey(KeyCode.S))
                r.AddForce(new Vector3(0,0, -force * runMultiplier), ForceMode.Force);

        }
        else
            isMoving = false;






        if (isRunning == true && isMoving == true && stamina > 0)
        {
            runMultiplier = 1.5f;
            stamina = stamina - staminaDecreaseRate;
        }
        


        if (stamina <= 0)
            isRunning = false;

        if (stamina < 100 && isRunning == false)
        {
            stamina = stamina + staminaCooldownRate;
        }

        if (isRunning == false)
        {
            runMultiplier = 1.0f;
        }



        a.SetFloat("RunMultiplier", runMultiplier * (force / ogForce) / 1.5f);
        a2.SetFloat("RunMultiplier", runMultiplier * (force / ogForce) / 1.5f);
        a3.SetFloat("RunMultiplier", runMultiplier * (force / ogForce) / 1.5f);
    }
}
