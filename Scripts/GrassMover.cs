using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMover : MonoBehaviour {

    public TreeCreator tc;

    Transform[] list;

    Vector3 currentPoint;

    public Transform player;
    public float maxDist;
    int iOffset;
    int yOffset;
    float lastI;
    float lastY;
    // Use this for initialization
    void Start()
    {
        list = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            list[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        float xDist = player.position.x - currentPoint.x;
        float yDist = player.position.y - currentPoint.y;

        if (Mathf.Abs(xDist) > maxDist)
        {
            float val = Mathf.Sign(xDist);

            Transform temp = null;

            if (val == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    list[i].position += new Vector3(30, 0, 0);
                    temp = list[i].transform;

                    list[i] = list[i + 3];
                    list[i + 3] = list[i + 6];
                    list[i + 6] = temp;
                }

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    list[i + 6].position += new Vector3(-30, 0, 0);
                    temp = list[i + 6].transform;

                    list[i + 6] = list[i + 3];
                    list[i + 3] = list[i];
                    list[i] = temp;
                }
            }

            currentPoint += new Vector3(val == 1 ? 10 : -10, 0, 0);
        }

        if (Mathf.Abs(yDist) > maxDist)
        {
            float val = Mathf.Sign(yDist);

            Transform temp = null;

            if (val == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    int newI = i * 3;

                    list[newI].position += new Vector3(0, 30, 0);
                    temp = list[newI].transform;

                    list[newI] = list[newI + 1];
                    list[newI + 1] = list[newI + 2];
                    list[newI + 2] = temp;
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int newI = i * 3;
                    list[newI + 2].position += new Vector3(0, -30, 0);
                    temp = list[newI + 2].transform;

                    list[newI + 2] = list[newI + 1];
                    list[newI + 1] = list[newI];
                    list[newI] = temp;
                }
            }

            currentPoint += new Vector3(0, val == 1 ? 10 : -10, 0);
        }
    }
}
