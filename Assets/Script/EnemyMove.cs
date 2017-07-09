using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public float rotationSpeed;
    public float raycastDist;
    static System.Random rnd = new System.Random();

    Vector2 target;

    Rigidbody2D rb2d;

    Move move;

    Vector2[] directions;

    // Use this for initialization
    void Start() {
        directions = new Vector2[] {
            Vector2.up, Vector2.down,
            Vector2.left, Vector2.right
        };
        move = new Move(gameObject, speed, rotationSpeed);
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 toMove = Vector2.zero;
        

        if (target.Equals(Vector2.up)) {
            move.Up();
        }
        if (target.Equals(Vector2.right)) {
            move.Right();
        }
        if (target.Equals(Vector2.left)) {
            move.Left();
        }
        if (target.Equals(Vector2.down)) {
            move.Down();
        }

        move.EndMove();
    }

    void TakeCover() {
        
    }
}
