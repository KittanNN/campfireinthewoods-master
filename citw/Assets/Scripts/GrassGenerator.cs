using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassGenerator : MonoBehaviour {


    Transform[] list;

	// Use this for initialization
	void Start () {
        list = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            list[i] = transform.GetChild(i);
        }
	}

    void Update()
    {

    }

}
