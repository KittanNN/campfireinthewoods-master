using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walk : MonoBehaviour {

    int run = 1;
    float stamina = 0;
    float staminaDrain = 1;
    float maxStamina = 100;
    bool isMoving;
    public Image img;

	// Use this for initialization
	void Start () {
        stamina = maxStamina;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //img.fillAmount = (stamina / maxStamina);

        checkStamina();

        


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
            if (Input.GetKey(KeyCode.A))
                transform.position -= new Vector3(.07f * run, 0, 0);

            if (Input.GetKey(KeyCode.D))
                transform.position += new Vector3(.07f * run, 0, 0);

            if (Input.GetKey(KeyCode.W))
                transform.position += new Vector3(0, 0, .07f * run);

            if (Input.GetKey(KeyCode.S))
                transform.position -= new Vector3(0,0, .07f * run);
        }


    }

    void checkStamina()
    {
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= 0 && isMoving)
        {
            if (stamina > (stamina - staminaDrain))
            {
                run = 2;
                stamina -= staminaDrain;
            }
           
        }
        else 
        {
            stamina += staminaDrain * .4f;
            run = 1;
        }


    }

}
