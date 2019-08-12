using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class givePos : MonoBehaviour {

    public Material[] mats;
    
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {
        //asd = new Vector4(0, 0, 1, 1);
        //asd = Camera.main.transform.forward;
        foreach (Material mat in mats)
        {
            mat.SetVector("_ForwardVec", transform.forward);
            mat.SetVector("_ObjWorldPos", transform.position);
        }
        
        
        //Material mat = sr.sharedMaterial;
        //mat.EnableKeyword("PosVec");
        //mat.SetVector("PosVec", new Vector4(0, 0, 1, 1));
        //sr.sharedMaterial = mat;


    }
}
