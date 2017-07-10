using UnityEngine;

public class Move {

    Transform transform;
    Rigidbody2D rb;
    float speed;
    float rotationSpeed;

    Vector2 toMove;

    public Move(GameObject gameObject, float speed, float rotationSpeed) {
        this.rotationSpeed = rotationSpeed;
        transform = gameObject.transform;
        rb = transform.parent.GetComponent<Rigidbody2D>();
        this.speed = speed;
    }

    public void Right() {
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

    public void Left() {
        toMove += Vector2.left;
        if (transform.rotation.eulerAngles.z > rotationSpeed + 90 ||
                transform.rotation.eulerAngles.z < -rotationSpeed + 90) {
            if (transform.rotation.eulerAngles.z < 270 && transform.rotation.eulerAngles.z > 90) {
                transform.Rotate(0, 0, -rotationSpeed);
            } else transform.Rotate(0, 0, rotationSpeed);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    public void Down() {
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

    public void Up () {
        toMove += Vector2.up;
        if (transform.rotation.eulerAngles.z > rotationSpeed) {
            if (transform.rotation.eulerAngles.z > 180) {
                transform.Rotate(0, 0, rotationSpeed);
            } else transform.Rotate(0, 0, -rotationSpeed);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void EndMove() {
        if (transform.rotation.eulerAngles.z > 360 - rotationSpeed) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        rb.AddForce(toMove * speed);
        toMove = Vector2.zero;
    }

}
