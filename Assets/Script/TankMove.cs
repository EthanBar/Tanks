using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public float rotationSpeed;
    public float controlStick;

    Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 toMove = Vector2.zero;

        if (Input.GetMouseButtonDown(0)) {
            GameObject newBullet = Instantiate(bullet).GetComponent<Bullet>().parent = gameObject;
        }

        if (Input.GetAxis("Vertical") > controlStick) {
            toMove += Vector2.up;
            if (transform.rotation.eulerAngles.z > rotationSpeed) {
                if (transform.rotation.eulerAngles.z > 180) {
                    transform.Rotate(0, 0, rotationSpeed);
                } else transform.Rotate(0, 0, rotationSpeed);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (Input.GetAxis("Vertical") < -controlStick) {
            toMove += Vector2.down;
            if (transform.rotation.eulerAngles.z > rotationSpeed + 180 ||
                transform.rotation.eulerAngles.z < -rotationSpeed + 180) {
                if (transform.rotation.eulerAngles.z > 180) {
                    transform.Rotate(0, 0, -rotationSpeed);
                } else transform.Rotate(0, 0, rotationSpeed);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
        }
        if (Input.GetAxis("Horizontal") < -controlStick) {
            toMove += Vector2.left;
            if (transform.rotation.eulerAngles.z > rotationSpeed + 90 ||
                transform.rotation.eulerAngles.z < -rotationSpeed + 90) {
                if (transform.rotation.eulerAngles.z < 270 || transform.rotation.eulerAngles.z > 90) {
                    transform.Rotate(0, 0, -rotationSpeed);
                } else transform.Rotate(0, 0, rotationSpeed);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
        }
        if (Input.GetAxis("Horizontal") > controlStick) {
            toMove += Vector2.right;
            if (transform.rotation.eulerAngles.z > rotationSpeed + 270 ||
                transform.rotation.eulerAngles.z < -rotationSpeed + 270) {
                if (transform.rotation.eulerAngles.z > 270 || transform.rotation.eulerAngles.z < 90) {
                    transform.Rotate(0, 0, -rotationSpeed);
                } else transform.Rotate(0, 0, rotationSpeed);
            } else {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }

        rb2d.MovePosition(new Vector2(transform.position.x, transform.position.y) + toMove * speed);

        if (transform.rotation.eulerAngles.z > 360 - rotationSpeed) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
	}
}
