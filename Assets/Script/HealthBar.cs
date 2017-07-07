using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Tank tank;
    RectTransform rect;

	// Use this for initialization
	void Start () {
        tank = transform.parent.parent.parent.GetComponent<Tank>();
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        rect.sizeDelta = new Vector2(tank.HP / tank.MaxHP, 0.1f);
	}
}
