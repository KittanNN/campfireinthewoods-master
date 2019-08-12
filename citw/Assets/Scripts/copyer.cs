using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyer : MonoBehaviour {

    public TreeCreator tc;
    public int first;
    public int second;
    public int size;

    public Vector3 offset;

    public GameObject copy;

	// Use this for initialization
	void Awake () {
        for (int i = 0; i < first; i++)
        {
            for (int y = 0; y < second; y++)
            {
                Instantiate(copy, new Vector3(i + (size * i), y + (size * y), 0) + offset, transform.rotation, transform);
            }
        }
	}

   void Start()
    {
        for (int i = 0; i < first; i++)
        {
            for (int y = 0; y < second; y++)
            {
                if (i != 1 || y != 1)
                {
                    tc.createTreeLot(new Vector3(i + (size * i), y + (size * y), 0) + offset);
                }

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
