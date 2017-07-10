using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject text;

    public float time;
    public float limit;

    float alpha;
    Transform player;
    Image img;

	// Use this for initialization
	void Start () {
        text.SetActive(false);
        alpha = 0;
        img = gameObject.GetComponent<Image>();
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null) {
            text.SetActive(true);
            alpha += time;
            if (alpha > limit) alpha = limit;
            img.color = new Color(0, 0, 0, alpha);

        }
	}
}
