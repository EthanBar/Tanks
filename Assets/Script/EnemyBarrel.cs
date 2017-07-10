using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrel : MonoBehaviour {

    GameObject player;
    public float shootTime;
    public GameObject bullet;
    public GameObject body;

    bool canShoot;

	// Use this for initialization
	void Start () {
        canShoot = true;
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        // Unity forums
        if (player != null) {
            Vector3 diff = player.transform.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            if (canShoot) Shoot();
        }
	}

    void Shoot() {
        // Disabling self collider to avoid raycast, bad hack
        body.GetComponent<BoxCollider2D>().enabled = false;


        RaycastHit2D hit;
        Vector3 rayDirection = player.transform.position - transform.position;
        hit = Physics2D.Raycast(transform.position, rayDirection);
        if (hit.transform == player.transform) {
            Instantiate(bullet).GetComponent<Bullet>().SetParents(body, gameObject);
            StartCoroutine(ShootTime());
        }

        body.GetComponent<BoxCollider2D>().enabled = true;
    }

    IEnumerator ShootTime() {
        canShoot = false;
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }
}
