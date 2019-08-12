using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventCreator : MonoBehaviour {

    public Object canvas;
    public Object HPBarObject;
    public List<HPBar> hpbars = new List<HPBar>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

        if (hpbars.Count != 0)
        {
            foreach (var bar in hpbars)
            {
                bar.UpdatePosition();
            }
        }

    }

    public void createAlert(string text, Vector3 offset, float speed)
    {
        alert(text, offset, speed);
    }

    public void createAlert(string text, Vector3 offset)
    {
        alert(text, offset, 1);
    }

    public void createAlert(string text)
    {
        alert(text, Vector3.zero, 1);
    }

    public void createAlert(string text, float speed)
    {
        alert(text, Vector3.zero, speed);
    }

    public void DestroyHpBar(HPBar bar)
    {
        Destroy(bar.img.gameObject);
        hpbars.Remove(bar);
    }

    void alert(string text, Vector3 offset, float speed)
    {
        Transform camera = Camera.main.transform;
        GameObject alert = (GameObject)Instantiate(canvas, (camera.position + camera.forward * 10) + offset, camera.rotation, transform);
        alert.transform.GetChild(0).GetComponent<Text>().text = text;
        alert.transform.GetChild(0).GetComponent<UI_Alert>().speed = speed;
    }

    public HPBar createHPBar(Transform obj,Vector3 offset)
    {
        GameObject hpbar = Instantiate(HPBarObject, transform) as GameObject;
        HPBar newBar = new HPBar();

        newBar.img = hpbar.GetComponent<Image>();
        newBar.hpbarTransform = hpbar.GetComponent<RectTransform>();
        newBar.originTransform = obj;
        newBar.Offset = offset;

        hpbars.Add(newBar);

        return newBar;
    }
}

public class HPBar
{
    int id;
    public Image img;
    public RectTransform hpbarTransform;
    public Transform originTransform;
    public Vector3 Offset;

    public void UpdatePosition()
    {
        hpbarTransform.position = originTransform.position + Offset;

    }

    public void updateImage(float health, float maxHealth)
    {
        img.fillAmount = health / maxHealth; //+ 1f -.5f
    }
}
