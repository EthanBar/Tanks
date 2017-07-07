using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public GameObject parent;
    public float speed;
    public float damage;
    Rigidbody2D rb2d;

    public GameObject deathParticle;

	// Use this for initialization
	void Start () {
        transform.position = parent.transform.position;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        rb2d.AddForce(transform.up * speed);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), parent.GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Tank") {
            collision.transform.GetComponent<Tank>().HP -= collision.relativeVelocity.magnitude * damage;
            Instantiate(deathParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Barrier") Destroy(gameObject);
    }
}
