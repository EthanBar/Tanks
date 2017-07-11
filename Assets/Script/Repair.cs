using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour {

    public float healAmount;
    public GameObject particle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.parent.name == "Player") {
            collision.transform.parent.GetComponent<Tank>().Heal(healAmount);
            Instantiate(particle, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
