using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCopy : MonoBehaviour {

    public GameObject copy;
    public float size;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            for (int y = 0; y < 10; y++)
            {
                Instantiate(copy, new Vector3(50 * i, 0 , 56.25f * y), Quaternion.Euler(90, 0, 0), transform);

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
