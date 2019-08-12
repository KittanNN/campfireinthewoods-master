using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class scalar : MonoBehaviour {


    public float wantedScale;

	// Use this for initialization
	void Start () {
        Vector3 s = GetComponent<SpriteRenderer>().bounds.size;
        s = new Vector3(transform.localScale.x * (wantedScale / s.x), transform.localScale.y * (wantedScale / s.y), transform.localScale.z * (wantedScale / s.z));
        transform.localScale = s;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
