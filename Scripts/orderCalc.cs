using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderCalc : MonoBehaviour {

    public bool isPlayer;

    SpriteRenderer sr;

	// Use this for initialization
	void Awake () {
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = (int)transform.position.y;
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isPlayer)
        {
            int plusShit =  Mathf.Sign((transform.position.y - (int)transform.position.y)) == 1 ? -1 : 1;
            sr.sortingOrder = (int)transform.position.y + plusShit;
        }
	}

}
