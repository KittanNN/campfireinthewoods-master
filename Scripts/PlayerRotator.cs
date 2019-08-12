using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour {

    public LayerMask mask;
    //public Transform forward;

	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
        Turning();
        //Vector3 asd = Input.mousePosition;
        //asd.z = 0;
        //transform.LookAt(Camera.main.ScreenToWorldPoint(asd), new Vector3(0, 0, 1));



        //transform.Rotate(new Vector3(-transform.rotation.x, 0,0));


        

        //Vector3 paska = new Vector3(0,0,transform.rotation.z);
        //transform.rotation = paska;
    }

    void Turning()
    {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, 200, mask))
        {




            float AngleRad = Mathf.Atan2( floorHit.point.x - transform.position.x, floorHit.point.z - transform.position.z);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            this.transform.rotation = Quaternion.Euler(0, AngleDeg,0);

            
        }
    }
}
