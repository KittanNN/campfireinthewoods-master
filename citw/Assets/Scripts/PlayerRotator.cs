using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour {

    public float maxLookAngle;
    public LayerMask mask;
    public AnimationController ac;
    public Vector3 forward;
    public Vector3 hit;

    Vector3 first;
    Vector3 second;
    int dir = 0;


    Attack at;
    //public Transform forward;

	// Use this for initialization
	void Awake () {
        at = GetComponent<Attack>();
	}

    private void Start()
    {
        forward = at.Angles[0];
        
    }

    // Update is called once per frame
    void Update () {
        Turning();

        
    }

    private void LateUpdate()
    {
        checkMaxTurning();
    }

    void Turning()
    {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit floorHit;
        

        if (Physics.Raycast(camRay, out floorHit, 200, mask))
        {

            hit = floorHit.point;


            float AngleRad = Mathf.Atan2( floorHit.point.x - transform.position.x, floorHit.point.z - transform.position.z);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            this.transform.rotation = Quaternion.Euler(0, AngleDeg,0);

            
        }
    }

    void checkMaxTurning()
    {
        int temp = ac.a2.GetInteger("Dir");
        if (temp != 8)
        {
            forward = at.Angles[dir];
            dir = temp;
        }
            

        hit.y = 0;

        if (Vector3.Angle(forward, hit - transform.position) > maxLookAngle)
        {
            //Vector3 first = (dir < 7) ? at.Angles[dir + 1] : at.Angles[0];
            //Vector3 second = (dir > 0) ? at.Angles[dir - 1] : at.Angles[7];


            first = Quaternion.Euler(0, maxLookAngle, 0) *  at.Angles[dir];
            second = Quaternion.Euler(0, 360 - maxLookAngle, 0) * at.Angles[dir];



            float firstDist = Vector3.Distance(hit - transform.position, first);
            float secondDist = Vector3.Distance(hit - transform.position, second);

            //print(firstDist + " : " + secondDist);

            if (firstDist < secondDist)
            {
                transform.LookAt(first + transform.position);
            }
            else
            {
                transform.LookAt(second + transform.position);
            }
        }
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(.75f, .75f, .75f, 1);

    //    Gizmos.DrawWireCube(hit, new Vector3(.5f, .5f, .5f));
    //    Gizmos.DrawWireCube(first + transform.position, new Vector3(.5f, .5f, .5f));
    //    Gizmos.DrawWireCube(second + transform.position, new Vector3(.5f, .5f, .5f));
    //}
}
