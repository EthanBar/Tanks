using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrel : MonoBehaviour {

    GameObject player;
    public float shootTime;
    public GameObject bullet;
    public GameObject body;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        InvokeRepeating("Shoot", 0, shootTime);
	}
	
	// Update is called once per frame
	void Update () {
        // Unity forums
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
	}

    void Shoot() {
        Instantiate(bullet).GetComponent<Bullet>().SetParents(body, gameObject);
    }
}
