 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public GameObject bullet;
    public float speed;
    public float rotationSpeed;
    public float raycastDist;
    static System.Random rnd = new System.Random();

    Rigidbody2D rb2d;

    Move move;

    Transform player;

    // Use this for initialization
    void Start() {
        player = GameObject.Find("Player").transform;
        move = new Move(gameObject, speed, rotationSpeed);
        rb2d = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 toMove = Vector2.zero;

        float xdiff = player.transform.position.x - transform.position.x;
        float ydiff = player.transform.position.y - transform.position.y;

        if (Mathf.Abs(xdiff) > Mathf.Abs(ydiff)) {
            if (xdiff > 0) {
                move.Right();
            } else move.Left();
        } else {
            if (ydiff > 0) {
                move.Up();
            } else move.Down();
        }

        move.EndMove();
    }

    void TakeCover() {
        
    }
}
