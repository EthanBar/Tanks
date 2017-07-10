using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public GameObject parent;
    public GameObject parentRotate;
    public float speed;
    public float damage;
    public float deathSpeed;
    Rigidbody2D rb2d;

    public GameObject deathParticle;

    float startTime;

    public void SetParents(GameObject parent, GameObject parentRotate) {
        this.parent = parent;
        this.parentRotate = parentRotate;
    }
   
    void Awake() {
        startTime = Time.time;
    }

	// Use this for initialization
	void Start () {
        transform.parent = GameObject.Find("Bullets").transform;
        transform.position = parent.transform.position;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        rb2d = GetComponent<Rigidbody2D>();
        //Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        if (parentRotate != null) {
            transform.rotation = parentRotate.transform.rotation;
        }
        rb2d.AddForce(transform.up * speed);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), parent.GetComponent<Collider2D>());
	}
	
	// Update is called once per frame
	void Update () {
        if (rb2d.velocity.magnitude < deathSpeed && Time.time - startTime > 1) Destroy(gameObject);
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
