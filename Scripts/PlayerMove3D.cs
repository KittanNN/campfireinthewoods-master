using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3D : MonoBehaviour {

    bool isMoving;
    Rigidbody r;
    public float force;

	// Use this for initialization
	void Awake () {
        r = GetComponent<Rigidbody>();
	}

    private void Update()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.A))
                r.AddForce(new Vector3(-force, 0,0), ForceMode.Force);

            if (Input.GetKey(KeyCode.D))
                r.AddForce(new Vector3(force, 0,0), ForceMode.Force);

            if (Input.GetKey(KeyCode.W))
                r.AddForce(new Vector3(0,0, force * 1.25f), ForceMode.Force);

            if (Input.GetKey(KeyCode.S))
                r.AddForce(new Vector3(0,0, -force * 1.25f), ForceMode.Force);
            

            


        }


	}
}
