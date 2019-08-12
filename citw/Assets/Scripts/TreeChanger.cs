using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChanger : MonoBehaviour {

    public Object[] list;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < transform.childCount; i ++)
        {
            int rng = Random.Range(0, 5);


            if (rng == 1)
            {
                Transform t = transform.GetChild(i);

                GameObject g = (GameObject)Instantiate(list[0], t.position, t.rotation, transform);


                

                Destroy(t.gameObject);

            } else if (rng == 2 || rng == 3)
            {
                Transform t = transform.GetChild(i);

                GameObject g = (GameObject)Instantiate(list[1], t.position, t.rotation, transform);



                Destroy(t.gameObject);
            }

        }
	}
	
	
}
