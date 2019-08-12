using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    bool isMoving;
    Rigidbody2D r;
    public float force;

	// Use this for initialization
	void Awake () {
        r = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.A))
                r.AddForce(new Vector2(-force, 0), ForceMode2D.Force);

            if (Input.GetKey(KeyCode.D))
                r.AddForce(new Vector2(force, 0), ForceMode2D.Force);

            if (Input.GetKey(KeyCode.W))
                r.AddForce(new Vector2(0, force), ForceMode2D.Force);

            if (Input.GetKey(KeyCode.S))
                r.AddForce(new Vector2(0, -force), ForceMode2D.Force);


        }


	}
}
