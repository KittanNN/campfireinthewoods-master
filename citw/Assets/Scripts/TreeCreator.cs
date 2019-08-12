using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreator : MonoBehaviour {

    public GameObject tree;
    GameObject parent;

    Vector3[] spawnList;
	void Awake () {
        parent = GameObject.FindWithTag("Trees");
        print(parent.name);


        //createTreeLot(transform.position);
	}

    public void createTreeLot(Vector3 pos)
    {
        int amount = Random.Range(8, 17);

        spawnList = new Vector3[amount];

        for (int i = 0; i < amount; i++)
        {
            Vector3 spawn = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), 0);


            bool goodToGo = true;

            for (int y = 0; y < i; y++)
            {
                if (Vector3.Distance(spawnList[y], spawn) < 2)
                {
                    goodToGo = false;
                }
            }



            while (goodToGo == false)
            {
                goodToGo = true;

                spawn = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), 0);

                for (int y = 0; y < i; y++)
                {
                    if (Vector3.Distance(spawnList[y], spawn) < 2)
                    {
                        goodToGo = false;
                    }
                }
            }

            spawnList[i] = spawn;

            Instantiate(tree, pos + spawn, Quaternion.Euler(0, 0, Random.Range(0, 360)), parent.transform);
        }
    }
}
