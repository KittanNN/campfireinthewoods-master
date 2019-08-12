using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campfireSize : MonoBehaviour {

    public float size;
    public Light light;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}

    private void Update()
    {
        size = light.range;
        transform.localScale = new Vector3(size > 2.3 ? 2.3f : size, size > 2 ? 2 : size, 1);
        size = size > 1 ? 1 : size;
        sr.color = new Color32((byte)(size * 255), (byte)(size * 255), (byte)(size * 255), 255);
    }

}
