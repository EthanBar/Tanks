using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Tank tank;
    RectTransform rect;
    RawImage img;

	// Use this for initialization
	void Start () {
        tank = transform.parent.parent.parent.GetComponent<Tank>();
        rect = GetComponent<RectTransform>();
        img = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        img.color = Color.Lerp(Color.red, Color.green, tank.HP / tank.MaxHP);
        rect.sizeDelta = new Vector2(tank.HP / tank.MaxHP, 0.1f);
	}
}
